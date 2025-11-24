using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace demo
{
    public partial class fm_LoaiSP : Form
    {
        public fm_LoaiSP()
        {
            InitializeComponent();
        }
        string str = "Server=localhost;Database=QLKhoHang;Trusted_Connection=true";
        private void themdulieuvaoDataGridView()
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng LSP
            string layDuLieu = "select MaLoai, TenLoai, MotaLoaiSP from LoaiSP";

            // Mở kết nối đến csdl và thực hiện các cv bên trong
            using (SqlConnection conn = new SqlConnection(str))
            {
                /* SqlDataAdapter là một đối tượng thuộc ADO.NET,
                sử dụng để thực hiện các thao tác truy vấn đến cơ sở dữ liệu SQL
                như truy vấn dữ liệu hoặc cập nhật dữ liệu */

                //Tạo một đối tượng SqlDataAdapter gọi là "adt"

                //Trong constructor của SqlDataAdapter cung cấp câu lệnh SQL để lấy dữ liệu (layDuLieu)
                //và đối tượng kết nối SqlConnection (trong trường hợp này là conn).
                SqlDataAdapter adt = new SqlDataAdapter(layDuLieu, conn);

                //Tạo một đối tượng DataTable mới để lưu trữ dữ liệu được lấy
                //(DataTable là một ctdl trong .NET Fw sử dụng để lưu trữ dữ liệu theo dạng bảng)
                DataTable dt = new DataTable();

                //Sử dụng đối tượng SqlDataAdapter(adt) "adt" để thực hiện truy vấn lấy dữ liệu từ cơ sở dữ liệu
                //thông qua câu lệnh SQL trong adt (layDuLieu). Kết quả của truy vấn sẽ được lưu vào đối tượng DataTable(dt)
                //thông qua phương thức Fill, biến đổi DL từ dạng được trả về bởi truy vấn vào ctdl của DataTable.
                adt.Fill(dt);

                // Xóa dữ liệu cũ trong DataGridView
                dataGridView_LoaiSP.Columns.Clear();

                // Thêm cột số thứ tự
                //Tạo một đối tượng mới của lớp DataGridViewTextBoxColumn
                //(một loại cột cho DataGridView được thiết kế để chứa dữ liệu văn bản)
                DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();

                //Gán giá trị "STT" cho thuộc tính HeaderText của cột.
                colSTT.HeaderText = "STT";

                // Thêm cột STT vào DataGridView có tên là dataGridView_LoaiSP
                dataGridView_LoaiSP.Columns.Add(colSTT);

                // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                if (dt.Columns.Count > 0)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
                        string tenCot = MapTenCot(column.ColumnName);
                        dataGridView_LoaiSP.Columns.Add(tenCot, tenCot);
                    }

                    // Thêm dữ liệu từ DataTable vào DataGridView
                    int stt = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        List<object> rowData = new List<object> { stt++ };
                        rowData.AddRange(row.ItemArray);
                        dataGridView_LoaiSP.Rows.Add(rowData.ToArray());
                    }
                }
            }
        }
        private void fm_LoaiSP_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            themdulieuvaoDataGridView();
            conn.Close();
        }
        private string MapTenCot(string tenCotCSLD)
        {
            // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
            switch (tenCotCSLD)
            {
                //trường hợp là cột MaLoai trong csdl thì đổi tên thành Mã Loại để hiển thị lên dgv
                case "MaLoai":
                    return "Mã loại";
                case "TenLoai":
                    return "Tên loại";
                case "MotaLoaiSP":
                    return "Mô tả";
                // Thêm các trường khác nếu cần
                default:
                    return tenCotCSLD;
            }
        }
        
        private void fm_LoaiSP_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dataGridView_LoaiSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                //Khai báo biến để lưu trữ dữ liệu nhập vào từ textBox
                string maLoai = txt_MaLoai.Text;
                string tenLoai = txt_TenLoai.Text;
                string moTa = txt_MotaLoaiSP.Text;

                //Lưu trữ lệnh SQL để điền thông tin đã điền vào từng cột có tên tương ứng trong csdl 
                string themDuLieu = "insert into LoaiSP values (@MaLoai, @TenLoai, @MotaLoaiSP)";
                using (SqlConnection conn = new SqlConnection(str))
                {
                    //Mở kết nối csdl
                    conn.Open();
                    //
                    SqlCommand cmd = new SqlCommand(themDuLieu, conn);

                    cmd.Parameters.AddWithValue("@MaLoai", txt_MaLoai.Text);
                    cmd.Parameters.AddWithValue("@TenLoai", txt_TenLoai.Text);
                    cmd.Parameters.AddWithValue("@MotaLoaiSP", txt_MotaLoaiSP.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                //Tự động cập nhật lại datagridview sau khi thêm 
                themdulieuvaoDataGridView();

                //Xóa thông tin điền trong textBox sau khi ấn thêm
                txt_MaLoai.Text = "";
                txt_MotaLoaiSP.Text = "";
                txt_TenLoai.Text = "";
            }
            catch 
            {
                MessageBox.Show("Loại sản phẩm này đã tồn tại. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void XoaDuLieuTuCSDL(string maLoai)
        {
            string xoaDuLieu = "DELETE FROM LoaiSP WHERE MaLoai = @MaLoai";

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(xoaDuLieu, conn);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);

                int rowsAffected = cmd.ExecuteNonQuery();
            }

            themdulieuvaoDataGridView();

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dataGridView_LoaiSP.SelectedRows.Count > 0)
                {
                    // Get the selected row's MaNV value
                    string selectedMaLoai = dataGridView_LoaiSP.SelectedRows[0].Cells[MapTenCot("MaLoai")].Value.ToString();

                    // Confirmation message before deletion
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Call the method to delete data
                        XoaDuLieuTuCSDL(selectedMaLoai);
                    }
                }
                else
                {
                    //Lệnh hiển thị thông báo, nếu ấn OK thì tiếp tục
                    MessageBox.Show("Vui lòng chọn một loại sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Mã loại sản phẩm này có liên quan tới dữ liệu khác. Vui lòng cập nhật lại phần mô tả.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            //Khi ấn nút hủy sẽ xóa đi dữ liệu đã nhập vào textbox
            txt_MaLoai.Text = "";
            txt_MotaLoaiSP.Text = "";
            txt_TenLoai.Text = "";
        }
        private bool isEditMode = false; // Biến kiểm tra xem đang ở chế độ chỉnh sửa hay không

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // Lấy giá trị MaLoai từ TextBox
                string maLoai = txt_MaLoai.Text;

                // Lưu trữ lệnh thực hiện cập nhật dữ liệu vào CSDL 
                string capNhat = "UPDATE LoaiSP SET TenLoai = @TenLoai, MotaLoaiSP = @MotaLoaiSP WHERE MaLoai = @MaLoai";
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(capNhat, conn);

                    cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                    cmd.Parameters.AddWithValue("@TenLoai", txt_TenLoai.Text);
                    cmd.Parameters.AddWithValue("@MotaLoaiSP", txt_MotaLoaiSP.Text);
                    //Lệnh sd để thực thi một truy vấn không trả về kết quả dữ liệu từ cơ sở dữ liệu.
                    //Thay vì trả về một bảng dữ liệu (như SELECT), nó thực hiện các truy vấn như INSERT, UPDATE, DELETE,
                    //hoặc các câu lệnh SQL khác không trả về dữ liệu.
                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                // Quay trở lại chế độ xem thông tin
                isEditMode = false;

                // Cập nhật lại DataGridView
                themdulieuvaoDataGridView();

                // Xóa dữ liệu trong TextBox
                txt_MaLoai.Text = "";
                txt_MotaLoaiSP.Text = "";
                txt_TenLoai.Text = "";
            }
            else
            {
                // Nếu không ở chế độ chỉnh sửa, có thể xử lý lưu mới ở đây (nếu cần)
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView_LoaiSP.SelectedRows.Count > 0)
            {
                // Lấy giá trị của MaLoai từ hàng được chọn
                string selectedMaLoai = dataGridView_LoaiSP.SelectedRows[0].Cells[MapTenCot("MaLoai")].Value.ToString();

                // Hiển thị thông tin của loại sản phẩm cần sửa lên các TextBox
                txt_MaLoai.Text = selectedMaLoai;
                txt_TenLoai.Text = dataGridView_LoaiSP.SelectedRows[0].Cells[MapTenCot("TenLoai")].Value.ToString();
                txt_MotaLoaiSP.Text = dataGridView_LoaiSP.SelectedRows[0].Cells[MapTenCot("MotaLoaiSP")].Value.ToString();

                // Chuyển sang chế độ chỉnh sửa
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TimKiemDuLieu(string tuKhoa)
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng LSP dựa trên từ khóa tìm kiếm
            string timKiem = "SELECT MaLoai, TenLoai, MotaLoaiSP FROM LoaiSP WHERE TenLoai LIKE @TuKhoa OR MotaLoaiSP LIKE @TuKhoa OR MaLoai like @TuKhoa";

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Sử dụng đối tượng SqlDataAdapter để thực hiện truy vấn lấy dữ liệu từ cơ sở dữ liệu
                using (SqlDataAdapter adt = new SqlDataAdapter(timKiem, conn))
                {
                    // Thêm tham số cho truy vấn
                    adt.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    // Tạo một đối tượng DataTable mới để lưu trữ dữ liệu từ truy vấn
                    DataTable dt = new DataTable();

                    // Sử dụng đối tượng SqlDataAdapter để điền dữ liệu vào DataTable
                    adt.Fill(dt);

                    // Xóa dữ liệu cũ trong DataGridView
                    dataGridView_LoaiSP.Columns.Clear();

                    // Thêm cột số thứ tự
                    DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
                    colSTT.HeaderText = "STT";
                    dataGridView_LoaiSP.Columns.Add(colSTT);

                    // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                    if (dt.Columns.Count > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
                            string tenCot = MapTenCot(column.ColumnName);
                            dataGridView_LoaiSP.Columns.Add(tenCot, tenCot);
                        }

                        // Thêm dữ liệu từ DataTable vào DataGridView
                        int stt = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            List<object> rowData = new List<object> { stt++ };
                            rowData.AddRange(row.ItemArray);
                            dataGridView_LoaiSP.Rows.Add(rowData.ToArray());
                        }
                    }
                }
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            // Gọi hàm tìm kiếm dữ liệu với từ khóa từ TextBox txt_TimKiem
            TimKiemDuLieu(txt_TimKiem.Text);
        }
    }
}
