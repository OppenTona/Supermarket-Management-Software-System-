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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Collections;
using System.Security.Cryptography;

namespace demo
{
    public partial class fm_TaiKhoan : Form
    {
        public fm_TaiKhoan()
        {
            InitializeComponent();
            // câu truy vấn
            string query = @"SELECT MaNV FROM NhanVien";
            SqlConnection con = new SqlConnection(str);

            //thực thi câu lệnh truy vấn với csdl được kết nối
            SqlCommand cmd = new SqlCommand(query, con);

            // mở csdl
            con.Open();

            // thực thi truy vấn và trả về một đối tượng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
            SqlDataReader rdr = cmd.ExecuteReader();           
           
            while (rdr.Read())
            {
                cb_MaNV.Items.Add(rdr[0].ToString());
            }
            rdr.Close();
            con.Close();
        }

        // chuỗi kết nối
        string str = "Server = localhost; Database=QLKhoHang;Trusted_Connection=true";

        private string MapTenCot(string tenCotCSLD)
        {
            // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
            switch (tenCotCSLD)
            {
                case "MaNV":
                    return "Mã nhân viên";
                case "TenDN":
                    return "Tên đăng nhập";
                case "MK":
                    return "Mật Khẩu";
                case "PhanQuyen":
                    return "Phân quyền";
                // Thêm các trường khác nếu cần
                default:
                    return tenCotCSLD;
            }
        }
        private void themdulieuvaoDataGridView()
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng QuanLyTK
            string layDuLieu = "select * from QuanLyTK";

            // Mở kết nối đến csdl và thực hiện các công việc bên trong
            using (SqlConnection con = new SqlConnection(str))
            {
                //sử dụng để thực hiện các thao tác truy vấn đến cơ sở dữ liệu SQL
                // Tạo một đối tượng SqlDataAdapter gọi là "adt"
                // Trong constructor của SqlDataAdapter cung cấp câu lệnh SQL để lấy dữ liệu (layDuLieu)
                SqlDataAdapter adt = new SqlDataAdapter(layDuLieu, con);

                // Tạo một đối tượng DataTable mới để lưu trữ dữ liệu được lấy
                // (DataTable là một cấu trúc dữ liệu trong .NET Framework được sử dụng để lưu trữ dữ liệu theo dạng bảng)
                DataTable dt = new DataTable();

                // Sử dụng đối tượng SqlDataAdapter(adt) "adt" để thực hiện truy vấn lấy dữ liệu từ cơ sở dữ liệu
                // thông qua câu lệnh SQL trong adt (layDuLieu). Kết quả của truy vấn sẽ được lưu vào đối tượng DataTable(dt)
                // thông qua phương thức Fill, biến đổi dữ liệu từ dạng được trả về bởi truy vấn vào cấu trúc dữ liệu của DataTable.
                adt.Fill(dt);

                // Xóa dữ liệu cũ trong DataGridView
                dataGridView_TaiKhoan.Columns.Clear();

                // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                if (dt.Columns.Count > 0)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
                        string tenCot = MapTenCot(column.ColumnName);
                        dataGridView_TaiKhoan.Columns.Add(tenCot, tenCot);
                    }
                    // Thêm dữ liệu từ DataTable vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView_TaiKhoan.Rows.Add(row.ItemArray);
                    }
                }
            }
        }
        //Hàm hỗ trợ xóa dữ liệu trong csdl
        private void XoaDuLieuTuCSDL(string maNV)
        {
            //Lưu trữ lệnh SQL để xóa dữ liệu trong csdl
            string xoaDuLieu = "DELETE FROM QuanLyTK WHERE MaNV = @MaNV";

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(xoaDuLieu, con);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
            }
            //Cập nhật lại dgv sau khi xóa
            themdulieuvaoDataGridView();
        }
        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fm_TaiKhoan_Load(object sender, EventArgs e)
        {
            // khởi tạo kết nối mới
            SqlConnection con = new SqlConnection(str);
            
            // mở kết nối
            con.Open();

            // gọi hàm để hiển thị dữ liệu lên dataGidView
            themdulieuvaoDataGridView();
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_MatKhau1_TextChanged(object sender, EventArgs e)
        {

        }
     
       
        
        private void dataGridView_TaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int i;
            i = dataGridView_TaiKhoan.CurrentRow.Index;
            cb_MaNV.Text = dataGridView_TaiKhoan.Rows[i].Cells[0].Value.ToString();
            txt_TenDangNhap1.Text = dataGridView_TaiKhoan.Rows[i].Cells[1].Value.ToString();
            txt_MatKhau1.Text = dataGridView_TaiKhoan.Rows[i].Cells[2].Value.ToString();
            checkedListBox_PhanQuyen.Text = dataGridView_TaiKhoan.Rows[i].Cells[3].Value.ToString();
            */
        }

        private void btn_Them3_Click(object sender, EventArgs e)
        {
            try
            {
                //Khai báo biến lưu trữ dữ liệu nhập vào từ textBox
                string maNV = cb_MaNV.Text;
                string tenDN = txt_TenDangNhap1.Text;
                string mk = txt_MatKhau1.Text;
                string phanQuyen = checkedListBox_PhanQuyen.Text;

                //Lưu trữ lệnh SQL để thêm dữ liệu vào bảng TaiKhoan với các cột tương ứng
                string themDuLieu = "insert into QuanLyTK values (@MaNV, @TenDN, @MK, @PhanQuyen)";
                using (SqlConnection con = new SqlConnection(str))
                {
                    //Mở kết nối csdl
                    con.Open();
                    // thực thi lệnh truy vấn
                    SqlCommand cmd = new SqlCommand(themDuLieu, con);

                    cmd.Parameters.AddWithValue("@MaNV", cb_MaNV.Text);
                    cmd.Parameters.AddWithValue("@TenDN", txt_TenDangNhap1.Text);
                    cmd.Parameters.AddWithValue("@MK", txt_MatKhau1.Text);
                    cmd.Parameters.AddWithValue("@PhanQuyen", checkedListBox_PhanQuyen.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                //Cập nhật lại dgv sau khi ấn thêm
                themdulieuvaoDataGridView();

                //Xóa dữ liệu trong textBox sau khi ấn Thêm
                cb_MaNV.Text = "";
                txt_TenDangNhap1.Text = "";
                txt_MatKhau1.Text = "";
                checkedListBox_PhanQuyen.Text = "";
            }
            catch
            {
                MessageBox.Show("Mã nhân viên chưa tồn tại", "Không thể thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void btn_Xoa3_Click(object sender, EventArgs e)
        {
            //Exe("DELETE FROM QuanLyTK WHERE MaNV = '" + cb_MaNV.Text + "' ");
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView_TaiKhoan.SelectedRows.Count > 0)
            {
                // Lấy giá trị của MaNV từ hàng được chọn
                string selectedMaNV = dataGridView_TaiKhoan.SelectedRows[0].Cells[MapTenCot("MaNV")].Value.ToString();

                // hiển thị thông báo và bắt buộc phải tương tác với thông bào này
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // gọi đến phương thức xóa dữ liệu
                    XoaDuLieuTuCSDL(selectedMaNV);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool isEditMode = false; // Biến kiểm tra xem đang ở chế độ chỉnh sửa hay không
        private void btn_Sua3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView_TaiKhoan.SelectedRows.Count > 0)
            {
                // Lấy giá trị của MaNV từ hàng được chọn
                string selectedMaNV = dataGridView_TaiKhoan.SelectedRows[0].Cells[MapTenCot("MaNV")].Value.ToString();

                // Hiển thị thông tin của tài khoản cần sửa lên các TextBox
                cb_MaNV.Text = selectedMaNV;
                txt_TenDangNhap1.Text = dataGridView_TaiKhoan.SelectedRows[0].Cells[MapTenCot("TenDN")].Value.ToString();
                txt_MatKhau1.Text = dataGridView_TaiKhoan.SelectedRows[0].Cells[MapTenCot("MK")].Value.ToString();
                checkedListBox_PhanQuyen.Text = dataGridView_TaiKhoan.SelectedRows[0].Cells[MapTenCot("PhanQuyen")].Value.ToString();

                // Chuyển sang chế độ chỉnh sửa
                isEditMode = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_Huy3_Click(object sender, EventArgs e)
        {
            // reset lại các thông tin đã điền 
            cb_MaNV.ResetText();
            txt_TenDangNhap1.ResetText();
            txt_MatKhau1.ResetText();
            checkedListBox_PhanQuyen.ResetText();
        }
       
        private void btn_Luu3_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                string maNV = cb_MaNV.Text;

                // Thực hiện cập nhật dữ liệu vào CSDL
                string updateQuery = "UPDATE QuanLyTK SET TenDN = @TenDN, MK = @MK, PhanQuyen = @PhanQuyen WHERE MaNV = @MaNV";

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(updateQuery, con);

                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TenDN", txt_TenDangNhap1.Text);
                    cmd.Parameters.AddWithValue("@MK", txt_MatKhau1.Text);
                    cmd.Parameters.AddWithValue("@PhanQuyen", checkedListBox_PhanQuyen.Text);
                   
                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                // Quay trở lại chế độ xem thông tin
                isEditMode = false;

                // Cập nhật lại DataGridView
                themdulieuvaoDataGridView();

                // Xóa dữ liệu trong TextBox
                cb_MaNV.Text = "";
                txt_TenDangNhap1.Text = "";
                txt_MatKhau1.Text = "";
                checkedListBox_PhanQuyen.Text = "";
                
            }
            else
            {
                // Nếu không ở chế độ chỉnh sửa, có thể xử lý lưu mới ở đây (nếu cần)
            }
        }
        private void TimKiemDuLieu(string tuKhoa)
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng QuanLyTK dựa trên từ khóa tìm kiếm
            string timKiemQuery = "SELECT * FROM QuanLyTK WHERE MaNV LIKE @TuKhoa OR TenDN LIKE @TuKhoa OR PhanQUyen like @TuKhoa ";

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                // Sử dụng đối tượng SqlDataAdapter để thực hiện truy vấn lấy dữ liệu từ cơ sở dữ liệu
                using (SqlDataAdapter adt = new SqlDataAdapter(timKiemQuery, con))
                {
                    // Thêm tham số cho truy vấn
                    adt.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    // Tạo một đối tượng DataTable mới để lưu trữ dữ liệu từ truy vấn
                    DataTable dt = new DataTable();

                    // Sử dụng đối tượng SqlDataAdapter để điền dữ liệu vào DataTable
                    adt.Fill(dt);

                    // Xóa dữ liệu cũ trong DataGridView
                    dataGridView_TaiKhoan.Columns.Clear();

                    // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                    if (dt.Columns.Count > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            dataGridView_TaiKhoan.Columns.Add(column.ColumnName, column.ColumnName);
                        }

                        // Thêm dữ liệu từ DataTable vào DataGridView
                        foreach (DataRow row in dt.Rows)
                        {
                            dataGridView_TaiKhoan.Rows.Add(row.ItemArray);
                        }
                    }
                }
            }


        }

        private void btn_TimKiem3_Click(object sender, EventArgs e)
        {
            // Gọi hàm tìm kiếm dữ liệu với từ khóa từ TextBox txt_TimKiem
            TimKiemDuLieu(txt_TimKiem3.Text);
        }
    }

}
