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
    public partial class fm_NhapKho : Form
    {
        public fm_NhapKho()
        {
            InitializeComponent();
        }
        string str = "Server = localhost; Database=QLKhoHang;Trusted_Connection=true";
        private void fm_NhapKho_Load(object sender, EventArgs e)
        {
            // tạo kết nối
            SqlConnection con = new SqlConnection(str);

            // mở kết nối
            con.Open();

            LoadComboboxLoaiSanPham();
            LoadComboboxNhaCungCap();
            themdulieuvaoDataGridView();
        }
        // đẩy dữ liệu lên cb_MaLoai1 từ bảng LoaiSP
        private void LoadComboboxLoaiSanPham()
        {
            SqlConnection con = new SqlConnection(str);
            string query = "SELECT MaLoai FROM LoaiSP";
           
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_MaLoai1.DataSource = dt;
            cb_MaLoai1.ValueMember = "MaLoai";
        }

        // đẩy dữ liệu lên cb_NhaCC từ bảng SanPham
        private void LoadComboboxNhaCungCap()
        {
            SqlConnection con = new SqlConnection(str);
            string query = "SELECT NhaCC FROM SanPham";
            
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_NhaCC1.DataSource = dt;
            cb_NhaCC1.ValueMember = "NhaCC";
        }
        private string MapTenCot(string tenCotCSLD)
        {
            // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
            switch (tenCotCSLD)
            {
                case "MaPN":
                    return "Số phiếu nhập";
                case "MaNV":
                    return "Mã nhân viên";
                case "MaLoai":
                    return "Mã loại sản phẩm";
                case "SoLuongNhap":
                    return "Số lượng";
                case "NhaCC":
                    return "Nhà cung cấp";
                case "NgayNhap":
                    return "Ngày nhập";
               
                // Thêm các trường khác nếu cần
                default:
                    return tenCotCSLD;
            }
        }
        private void themdulieuvaoDataGridView()
        {
            // Lưu trữ lệnh SQL để truy vấn các cột trong bảng NhapKho
            string layDuLieu = "select * from NhapKho";

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
                dataGridView_NhapKho.Columns.Clear();

                // Kiểm tra xem có cột nào trong DataTable không, nếu có thì thêm vào DataGridView
                if (dt.Columns.Count > 0)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        // Ánh xạ tên cột từ CSDL vào tên cột trong DataGridView
                        string tenCot = MapTenCot(column.ColumnName);
                        dataGridView_NhapKho.Columns.Add(tenCot, tenCot);
                    }

                    // Thêm dữ liệu từ DataTable vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView_NhapKho.Rows.Add(row.ItemArray);
                    }
                }
            }

        }

        private void btn_NhapHang_Click(object sender, EventArgs e)
        {
            //Khai báo biến lưu trữ dữ liệu nhập vào từ textBox
            string soPhieuNhap = txt_SoPN.Text;
            int soLuong = int.Parse(txt_SoLuong.Text);
            string maNhanVien = txt_MaNV.Text;
            string Maloai = cb_MaLoai1.Text;
            string nhaCungCap = cb_NhaCC1.Text;
            DateTime ngayNhap = dateTimePicker1.Value;

            //Lưu trữ lệnh SQL để thêm dữ liệu vào bảng NhapKho với các cột tương ứng
            string query = "INSERT INTO NhapKho VALUES(@MaPN, @MaNV, @MaLoai, @SoLuongNhap, @NhaCC, @NgayNhap)"; 
            using(SqlConnection con = new SqlConnection(str))
            {
                //Mở kết nối csdl
                con.Open();
                // 
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@MaPN", txt_SoPN.Text);
                cmd.Parameters.AddWithValue("@MaNV", txt_MaNV.Text);
                cmd.Parameters.AddWithValue("@MaLoai", cb_MaLoai1.Text);
                cmd.Parameters.AddWithValue("@SoLuongNhap", txt_SoLuong.Text);
                cmd.Parameters.AddWithValue("@NhaCC", cb_NhaCC1.Text);
                cmd.Parameters.AddWithValue("@NgayNhap", dateTimePicker1.Value);
              
                int rowsAffected = cmd.ExecuteNonQuery();
            }
            //Cập nhật lại dgv sau khi ấn thêm
            themdulieuvaoDataGridView();

            //Xóa dữ liệu trong textBox sau khi ấn Nhập hàng
            cb_MaLoai1.Text = "";
            txt_MaNV.Text = "";
            cb_MaLoai1.Text = "";
            txt_SoLuong.Text = "";
            cb_NhaCC1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
         
        }
    }
}
