using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class fm_NhanVien : Form
    {
        public fm_NhanVien()
        {
            InitializeComponent();
        }
        string str = "Server=localhost;Database=QLKhoHang;Trusted_Connection=true";
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private string MapTenCot(string tenCotCSLD)
        {
            // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
            switch (tenCotCSLD)
            {
                case "MaNV":
                    return "Mã nhân viên";
                case "TenNV":
                    return "Tên nhân viên";
                case "ChucVu":
                    return "Chức vụ";
                case "NgaySinh":
                    return "Ngày sinh";
                case "GioiTinh":
                    return "Giới tính";
                case "SDT":
                    return "Số điện thoại";
                case "DiaChi":
                    return "Địa chỉ";
                case "Email":
                    return "Email";
                // Thêm các trường khác nếu cần
                default:
                    return tenCotCSLD;
            }
        }
        private void themdulieuvaoDataGridView()
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng LSP
            string layDuLieu = "select MaNV, TenNV, ChucVu, NgaySinh, GioiTinh, SDT, DiaChi, Email from NhanVien";

            // Mở kết nối đến csdl và thực hiện các công việc bên trong
            using (SqlConnection conn = new SqlConnection(str))
            {
                /* SqlDataAdapter là một đối tượng thuộc ADO.NET,
                sử dụng để thực hiện các thao tác truy vấn đến cơ sở dữ liệu SQL
                như truy vấn dữ liệu hoặc cập nhật dữ liệu */

                // Tạo một đối tượng SqlDataAdapter gọi là "adt"

                // Trong constructor của SqlDataAdapter cung cấp câu lệnh SQL để lấy dữ liệu (layDuLieu)
                // và đối tượng kết nối SqlConnection (trong trường hợp này là conn).
                SqlDataAdapter adt = new SqlDataAdapter(layDuLieu, conn);

                // Tạo một đối tượng DataTable mới để lưu trữ dữ liệu được lấy
                // (DataTable là một cấu trúc dữ liệu trong .NET Framework được sử dụng để lưu trữ dữ liệu theo dạng bảng)
                DataTable dt = new DataTable();

                // Sử dụng đối tượng SqlDataAdapter(adt) "adt" để thực hiện truy vấn lấy dữ liệu từ cơ sở dữ liệu
                // thông qua câu lệnh SQL trong adt (layDuLieu). Kết quả của truy vấn sẽ được lưu vào đối tượng DataTable(dt)
                // thông qua phương thức Fill, biến đổi dữ liệu từ dạng được trả về bởi truy vấn vào cấu trúc dữ liệu của DataTable.
                adt.Fill(dt);

                // Xóa dữ liệu cũ trong DataGridView
                dataGridView_NV.Columns.Clear();

                // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                if (dt.Columns.Count > 0)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
                        string tenCot = MapTenCot(column.ColumnName);
                        dataGridView_NV.Columns.Add(tenCot, tenCot);
                    }

                    // Thêm dữ liệu từ DataTable vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView_NV.Rows.Add(row.ItemArray);
                    }
                }
            }

        }

        //Hàm hỗ trợ xóa dữ liệu trong csdl
        private void XoaDuLieuTuCSDL(string maNV)
        {
            //Lưu trữ lệnh SQL để xóa dữ liệu trong csdl
            string xoaDuLieu = "DELETE FROM NhanVien WHERE MaNV = @MaNV";

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(xoaDuLieu, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
            }
            //Cập nhật lại dgv sau khi xóa
            themdulieuvaoDataGridView();
        }
        private void fm_NhanVien_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            themdulieuvaoDataGridView();
        }
        
        private void btn_Them2_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Khai báo biến lưu trữ dữ liệu nhập vào từ textBox
                string maNV = txt_MaNV2.Text;
                string tenNv = txt_TenNV.Text;
                string email = txt_Email.Text;
                string sdt = txt_SDT.Text;
                string chucVu = cb_ChucVu.Text;
                string gioiTinh = cb_GioiTinh.Text;
                string diaChi = txt_DiaChi.Text;
                DateTime ngaySinh = dateTimePicker5.Value;

                //Lưu trữ lệnh SQL để thêm dữ liệu vào bảng NV với các cột tương ứng
                string themDuLieu = "insert into NhanVien values (@MaNV, @TenNV, @ChucVu, @GioiTinh, @Sdt, @NgaySinh, @DiaChi, @Email)";
                using (SqlConnection conn = new SqlConnection(str))
                {
                    //Mở kết nối csdl
                    conn.Open();
                    // 
                    SqlCommand cmd = new SqlCommand(themDuLieu, conn);

                    cmd.Parameters.AddWithValue("@MaNV", txt_MaNV2.Text);
                    cmd.Parameters.AddWithValue("@TenNV", txt_TenNV.Text);
                    cmd.Parameters.AddWithValue("@ChucVu", cb_ChucVu.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", cb_GioiTinh.Text);
                    cmd.Parameters.AddWithValue("@Sdt", txt_SDT.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker5.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                //Cập nhật lại dgv sau khi ấn thêm
                themdulieuvaoDataGridView();

                //Xóa dữ liệu trong textBox sau khi ấn Thêm
                txt_MaNV2.Text = "";
                txt_TenNV.Text = "";
                txt_Email.Text = "";
                cb_ChucVu.Text = "";
                cb_GioiTinh.Text = "";
                txt_SDT.Text = "";
                txt_DiaChi.Text = "";
                dateTimePicker5.Value = DateTime.Now;
            }
            catch 
            {
                MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng điền mã khác.", "Không thể thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool isEditMode = false; // Biến kiểm tra xem đang ở chế độ chỉnh sửa hay không
        private void btn_Sua2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView_NV.SelectedRows.Count > 0)
            {
                // Lấy giá trị của MaNV từ hàng được chọn
                string selectedMaNV = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("MaNV")].Value.ToString();

                // Hiển thị thông tin của nhân viên cần sửa lên các TextBox và DateTimePicker
                txt_MaNV2.Text = selectedMaNV;
                txt_TenNV.Text = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("TenNV")].Value.ToString();
                cb_ChucVu.Text = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("ChucVu")].Value.ToString();
                cb_GioiTinh.Text = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("GioiTinh")].Value.ToString();
                txt_SDT.Text = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("SDT")].Value.ToString();

                // Kiểm tra và chuyển đổi kiểu dữ liệu của NgaySinh từ cột "NgaySinh" trong DataGridView
                if (dataGridView_NV.SelectedRows[0].Cells[MapTenCot("NgaySinh")].Value != null && dataGridView_NV.SelectedRows[0].Cells[MapTenCot("NgaySinh")].Value != DBNull.Value)
                {
                    dateTimePicker5.Value = Convert.ToDateTime(dataGridView_NV.SelectedRows[0].Cells[MapTenCot("NgaySinh")].Value);
                }

                txt_DiaChi.Text = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("DiaChi")].Value.ToString();
                txt_Email.Text = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("Email")].Value.ToString();

                // Chuyển sang chế độ chỉnh sửa
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_Xoa2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dataGridView_NV.SelectedRows.Count > 0)
                {
                    // Get the selected row's MaNV value
                    string selectedMaNV = dataGridView_NV.SelectedRows[0].Cells[MapTenCot("MaNV")].Value.ToString();

                    // Confirmation message before deletion
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Call the method to delete data
                        XoaDuLieuTuCSDL(selectedMaNV);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Mã nhân viên liên quan tới dữ liệu khác. Vui lòng cập nhật lại phần mô tả.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Luu2_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                string maNV = txt_MaNV2.Text;

                // Thực hiện cập nhật dữ liệu vào CSDL
                string updateQuery = "UPDATE NhanVien SET TenNV = @TenNV, ChucVu = @ChucVu, GioiTinh = @GioiTinh, " +
                                     "Sdt = @Sdt, NgaySinh = @NgaySinh, DiaChi = @DiaChi, Email = @Email WHERE MaNV = @MaNV";

                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TenNV", txt_TenNV.Text);
                    cmd.Parameters.AddWithValue("@ChucVu", cb_ChucVu.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", cb_GioiTinh.Text);
                    cmd.Parameters.AddWithValue("@Sdt", txt_SDT.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker5.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                // Quay trở lại chế độ xem thông tin
                isEditMode = false;

                // Cập nhật lại DataGridView
                themdulieuvaoDataGridView();

                // Xóa dữ liệu trong TextBox
                txt_MaNV2.Text = "";
                txt_TenNV.Text = "";
                txt_Email.Text = "";
                cb_ChucVu.Text = "";
                cb_GioiTinh.Text = "";
                txt_SDT.Text = "";
                txt_DiaChi.Text = "";
                dateTimePicker5.Value = DateTime.Now;
            }
            else
            {
                // Nếu không ở chế độ chỉnh sửa, có thể xử lý lưu mới ở đây (nếu cần)
            }

        }

        private void btn_Huy2_Click(object sender, EventArgs e)
        {
            // Khi ấn nút hủy sẽ xóa đi dữ liệu đã nhập vào textbox
            txt_MaNV2.Text = "";
            txt_TenNV.Text = "";
            txt_Email.Text = "";
            cb_ChucVu.Text = "";
            cb_GioiTinh.Text = "";
            txt_SDT.Text = "";
            txt_DiaChi.Text = "";
            dateTimePicker5.Value = DateTime.Now;
        }
        private void TimKiemDuLieu(string tuKhoa)
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng LSP dựa trên từ khóa tìm kiếm
            string timKiemQuery = "SELECT MaNV, TenNV, ChucVu, NgaySinh, GioiTinh, SDT, DiaChi, Email FROM NhanVien WHERE MaNV LIKE @TuKhoa OR TenNV LIKE @TuKhoa OR ChucVu like @TuKhoa OR GioiTinh like @TuKhoa OR NgaySinh like @TuKhoa OR SDT like @TuKhoa OR DiaChi like @TuKhoa OR Email like @TuKhoa";

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                // Sử dụng đối tượng SqlDataAdapter để thực hiện truy vấn lấy dữ liệu từ cơ sở dữ liệu
                using (SqlDataAdapter adt = new SqlDataAdapter(timKiemQuery, conn))
                {
                    // Thêm tham số cho truy vấn
                    adt.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    // Tạo một đối tượng DataTable mới để lưu trữ dữ liệu từ truy vấn
                    DataTable dt = new DataTable();

                    // Sử dụng đối tượng SqlDataAdapter để điền dữ liệu vào DataTable
                    adt.Fill(dt);

                    // Xóa dữ liệu cũ trong DataGridView
                    dataGridView_NV.Columns.Clear();

                    // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                    if (dt.Columns.Count > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            dataGridView_NV.Columns.Add(column.ColumnName, column.ColumnName);
                        }

                        // Thêm dữ liệu từ DataTable vào DataGridView
                        foreach (DataRow row in dt.Rows)
                        {
                            dataGridView_NV.Rows.Add(row.ItemArray);
                        }
                    }
                }
            }


        }

        private void btn_TimKiem2_Click(object sender, EventArgs e)
        {

            // Gọi hàm tìm kiếm dữ liệu với từ khóa từ TextBox txt_TimKiem
            TimKiemDuLieu(txt_TimKiem2.Text);
        }
    }
}
