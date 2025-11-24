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
    public partial class fm_SanPham : Form
    {
        public fm_SanPham()
        {
            InitializeComponent();
            string query = @"SELECT MaLoai FROM LoaiSP";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                cb_MaLoai.Items.Add(rdr[0].ToString());
            }
            rdr.Close();
            con.Close();
        }
        string str = "Server=localhost;Database=QLKhoHang;Trusted_Connection=true";

        private string MapTenCot(string tenCotCSLD)
        {
            // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
            switch (tenCotCSLD)
            {
                case "MaLoai":
                    return "Mã loại";
                case "MaSP":
                    return "Mã sản phẩm";
                case "TenSP":
                    return "Tên sản phẩm";
                case "DonViTinh":
                    return "Đơn vị tính";
                case "NgaySX":
                    return "Ngày sản xuất";
                case "HanSD":
                    return "Hạn sử dụng";
                case "Gia":
                    return "Giá vốn";
                case "NhaCC":
                    return "Nhà cung cấp";
                case "MotaSP":
                    return "Mô tả";
                // Thêm các trường khác nếu cần
                default:
                    return tenCotCSLD;
            }
        }

        private void themdulieuvaoDataGridView()
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng LSP
            string layDuLieu = "select * from SanPham";

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
                dataGridView_SP.Columns.Clear();

                // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                if (dt.Columns.Count > 0)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
                        string tenCot = MapTenCot(column.ColumnName);
                        dataGridView_SP.Columns.Add(tenCot, tenCot);
                    }

                    // Thêm dữ liệu từ DataTable vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView_SP.Rows.Add(row.ItemArray);
                    }
                }
            }

        }

        //Hàm hỗ trợ xóa dữ liệu trong csdl
        private void XoaDuLieuTuCSDL(string maSP)
        {
            //Lưu trữ lệnh SQL để xóa dữ liệu trong csdl
            string xoaDuLieu = "DELETE FROM SanPham WHERE MaSP = @MaSP";

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(xoaDuLieu, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                int rowsAffected = cmd.ExecuteNonQuery();
            }
            //Cập nhật lại dgv sau khi xóa
            themdulieuvaoDataGridView();
        }
        private void fm_SanPham_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            themdulieuvaoDataGridView();
        }

        private void btn_Them1_Click(object sender, EventArgs e)
        {
            try
            {
                //Khai báo biến lưu trữ dữ liệu nhập vào từ textBox
                string maLoai = cb_MaLoai.Text;
                string maSP = txt_MaSP.Text;
                string tenSP = txt_TenSP.Text;
                string dvTinh = txt_DonviTinh.Text;
                DateTime ngaySX = dateTimePicker3.Value;
                DateTime hanSD = dateTimePicker4.Value;
                string nhaCC = cb_NhaCC.Text;
                int gia = int.Parse(txt_GiaVon.Text);
                string mota = txt_MotaSP.Text;

                //Lưu trữ lệnh SQL để thêm dữ liệu vào bảng NV với các cột tương ứng
                string themDuLieu = "insert into SanPham values (@MaLoai, @MaSP, @TenSP, @DonViTinh, @NgaySX, @HanSD, @Gia, @NhaCC, @MotaSP)";
                using (SqlConnection conn = new SqlConnection(str))
                {
                    //Mở kết nối csdl
                    conn.Open();
                    // 
                    SqlCommand cmd = new SqlCommand(themDuLieu, conn);

                    cmd.Parameters.AddWithValue("@MaLoai", cb_MaLoai.Text);
                    cmd.Parameters.AddWithValue("@MaSP", txt_MaSP.Text);
                    cmd.Parameters.AddWithValue("@TenSP", txt_TenSP.Text);
                    cmd.Parameters.AddWithValue("@DonViTinh", txt_DonviTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySX", dateTimePicker3.Value);
                    cmd.Parameters.AddWithValue("@HanSD", dateTimePicker4.Value);
                    cmd.Parameters.AddWithValue("@Gia", txt_GiaVon.Text);
                    cmd.Parameters.AddWithValue("@NhaCC", cb_NhaCC.Text);
                    cmd.Parameters.AddWithValue("@MotaSP", txt_MotaSP.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                //Cập nhật lại dgv sau khi ấn thêm
                themdulieuvaoDataGridView();

                //Xóa dữ liệu trong textBox sau khi ấn Thêm
                cb_MaLoai.Text = "";
                txt_MaSP.Text = "";
                txt_TenSP.Text = "";
                txt_DonviTinh.Text = "";
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker4.Value = DateTime.Now;
                txt_GiaVon.Text = "";
                cb_NhaCC.Text = "";
                txt_MotaSP.Text = "";

            }
            catch
            {
                MessageBox.Show("Mã loại sản phẩm đã tồn tại! Vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.YesNo);
            }

        }
        private bool isEditMode = false; // Biến kiểm tra xem đang ở chế độ chỉnh sửa hay không

        private void btn_Sua1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView_SP.SelectedRows.Count > 0)
            {
                // Lấy giá trị của MaSP từ hàng được chọn
                string selectedMaSP = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("MaSP")].Value.ToString();

                // Hiển thị thông tin của nhân viên cần sửa lên các TextBox và DateTimePicker
                txt_MaSP.Text = selectedMaSP;
                cb_MaLoai.Text = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("MaLoai")].Value.ToString();
                txt_TenSP.Text = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("TenSP")].Value.ToString();
                txt_DonviTinh.Text = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("DonViTinh")].Value.ToString();
               

                // Kiểm tra và chuyển đổi kiểu dữ liệu của NgaySinh từ cột "NgaySinh" trong DataGridView
                if (dataGridView_SP.SelectedRows[0].Cells[MapTenCot("NgaySX")].Value != null && dataGridView_SP.SelectedRows[0].Cells[MapTenCot("NgaySX")].Value != DBNull.Value)
                {
                    dateTimePicker3.Value = Convert.ToDateTime(dataGridView_SP.SelectedRows[0].Cells[MapTenCot("NgaySX")].Value);
                }
                if (dataGridView_SP.SelectedRows[0].Cells[MapTenCot("HanSD")].Value != null && dataGridView_SP.SelectedRows[0].Cells[MapTenCot("NgaySX")].Value != DBNull.Value)
                {
                    dateTimePicker4.Value = Convert.ToDateTime(dataGridView_SP.SelectedRows[0].Cells[MapTenCot("HanSD")].Value);
                }
                txt_GiaVon.Text = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("Gia")].Value.ToString();
                cb_NhaCC.Text = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("NhaCC")].Value.ToString();
                txt_MotaSP.Text = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("MotaSP")].Value.ToString();

                // Chuyển sang chế độ chỉnh sửa
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Xoa1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dataGridView_SP.SelectedRows.Count > 0)
                {
                    // Get the selected row's MaNV value
                    string selectedMaSP = dataGridView_SP.SelectedRows[0].Cells[MapTenCot("MaSP")].Value.ToString();

                    // Confirmation message before deletion
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Call the method to delete data
                        XoaDuLieuTuCSDL(selectedMaSP);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại ở dữ liệu khác!", "Không thể xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }      
        }

        private void btn_Luu1_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                string maSP = txt_MaSP.Text;

                // Thực hiện cập nhật dữ liệu vào CSDL
                string updateQuery = "UPDATE SanPham SET MaLoai = @MaLoai, TenSP = @TenSP, DonViTinh = @DonViTinh, NgaySX = @NgaySX, " +
                                     "HanSD = @HanSD, Gia = @Gia, NhaCC = @NhaCC, MotaSP = @MotaSP WHERE MaSP = @MaSP";

                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@MaLoai", cb_MaLoai.Text);
                    cmd.Parameters.AddWithValue("@TenSP", txt_TenSP.Text);
                    cmd.Parameters.AddWithValue("@DonViTinh", txt_DonviTinh.Text);
                    cmd.Parameters.AddWithValue("@NgaySX", dateTimePicker3.Value);
                    cmd.Parameters.AddWithValue("@HanSD", dateTimePicker4.Value);
                    cmd.Parameters.AddWithValue("@Gia", txt_GiaVon.Text);
                    cmd.Parameters.AddWithValue("@NhaCC", cb_NhaCC.Text);
                    cmd.Parameters.AddWithValue("@MotaSP", txt_MotaSP.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                // Quay trở lại chế độ xem thông tin
                isEditMode = false;

                // Cập nhật lại DataGridView
                themdulieuvaoDataGridView();

                // Xóa dữ liệu trong TextBox
                cb_MaLoai.Text = "";
                txt_MaSP.Text = "";
                txt_TenSP.Text = "";
                txt_DonviTinh.Text = "";
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker4.Value = DateTime.Now;
                txt_GiaVon.Text = "";
                cb_NhaCC.Text = "";
                txt_MotaSP.Text = "";
            }
            else
            {
                // Nếu không ở chế độ chỉnh sửa, có thể xử lý lưu mới ở đây (nếu cần)
            }
        }

        private void btn_Huy1_Click(object sender, EventArgs e)
        {
            cb_MaLoai.Text = "";
            txt_MaSP.Text = "";
            txt_TenSP.Text = "";
            txt_DonviTinh.Text = "";
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            txt_GiaVon.Text = "";
            cb_NhaCC.Text = "";
            txt_MotaSP.Text = "";
        }
        private void TimKiemDuLieu(string tuKhoa)
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng LSP dựa trên từ khóa tìm kiếm
            string timKiemQuery = "SELECT * FROM SanPham WHERE MaSP = @MaSP OR MaLoai LIKE @TuKhoa OR TenSP LIKE @TuKhoa OR NgaySX like @TuKhoa OR HanSD like @TuKhoa OR MotaSP like @TuKhoa OR NhaCC like @TuKhoa";

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
                    dataGridView_SP.Columns.Clear();

                    // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                    if (dt.Columns.Count > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            dataGridView_SP.Columns.Add(column.ColumnName, column.ColumnName);
                        }

                        // Thêm dữ liệu từ DataTable vào DataGridView
                        foreach (DataRow row in dt.Rows)
                        {
                            dataGridView_SP.Rows.Add(row.ItemArray);
                        }
                    }
                }
            }


        }

        private void btn_TimKiem1_Click(object sender, EventArgs e)
        {
            // Gọi hàm tìm kiếm dữ liệu với từ khóa từ TextBox txt_TimKiem
            TimKiemDuLieu(txt_TimKiem1.Text);
        }
    }
}
