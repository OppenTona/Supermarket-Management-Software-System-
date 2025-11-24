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
    public partial class fm_XuatKho : Form
    {
        public fm_XuatKho()
        {
            InitializeComponent();
        }

        private void fm_XuatKho_Load(object sender, EventArgs e)
        {
            // Khai báo và khởi tạo đối tượng kết nối đến cơ sở dữ liệu SQL Server
            SqlConnection conn = new SqlConnection("Server=localhost;Database=QLKhoHang;Trusted_Connection=true");
            
            // Mở kết nối đến cơ sở dữ liệu
            conn.Open();
            try
            {
                // Chuỗi truy vấn SQL để lấy dữ liệu từ bảng LoaiSP
                string SP = "SELECT TenLoai FROM LoaiSP";

                // Tạo một đối tượng SqlCommand để thực thi truy vấn
                SqlCommand SanPham = new SqlCommand(SP, conn);

                // Thực thi truy vấn và trả về một đối tượng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
                SqlDataReader reader = SanPham.ExecuteReader();

                // Đẩy dữ liệu từ cột "TenSP" của mỗi hàng trong kết quả truy vấn vào ComboBox
                while (reader.Read())
                {
                    // Thêm một mục vào ComboBox với giá trị là dữ liệu đọc được từ cột "TenLoai"
                    cb_TenLoai2.Items.Add(reader["TenLoai"].ToString());
                }

                // Đóng SqlDataReader sau khi đọc xong dữ liệu
                reader.Close();
                string sqlQuery = "select XuatKho.MaPX, XuatKho.MaNV, LoaiSP.TenLoai, XuatKho.SoLuong from LoaiSP, XuatKho where LoaiSP.MaLoai = XuatKho.MaLoai";

                // Tạo một đối tượng SqlDataAdapter để thực thi truy vấn và lấy dữ liệu từ cơ sở dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);

                // Tạo một DataTable để lưu trữ kết quả từ truy vấn
                DataTable data = new DataTable();

                // Xóa tất cả các cột hiện có trong DataGridView
                dataGridView_XuatKho.Columns.Clear();

                // Đổ dữ liệu từ truy vấn vào DataTable
                adapter.Fill(data);

                // Thêm một cột mới vào DataTable để lưu trữ ngày xuất
                data.Columns.Add("Ngày xuất", typeof(string));

                // Đặt giá trị cho cột "Ngày xuất" trong mỗi hàng của DataTable
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["Ngày xuất"] = dateTimePicker2.Text;
                }

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dataGridView_XuatKho.DataSource = data;

                // Đặt tên cho các cột trong DataGridView
                dataGridView_XuatKho.Columns[0].HeaderText = "Số phiếu xuất";
                dataGridView_XuatKho.Columns[1].HeaderText = "Mã nhân viên";
                dataGridView_XuatKho.Columns[2].HeaderText = "Tên loại sản phẩm";
                dataGridView_XuatKho.Columns[3].HeaderText = "Số lượng";
            
            }
            // Xử lý ngoại lệ nếu có bất kỳ lỗi nào xảy ra trong quá trình thực thi truy vấn
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            // Luôn đảm bảo rằng kết nối đến cơ sở dữ liệu được đóng sau khi hoàn thành công việc
            finally
            {
                conn.Close();
            }
        }

        private void btn_XuatHang_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=localhost;Database=QLKhoHang;Trusted_Connection=true");
                // Mở kết nối đến cơ sở dữ liệu
                conn.Open();

                // Khởi tạo một đối tượng SqlCommand
                SqlCommand cmd = new SqlCommand();

                // Gán kết nối cho đối tượng SqlCommand
                cmd.Connection = conn;

                // Chuỗi truy vấn SQL để lấy mã loại từ bảng LoaiSP dựa trên tên sản phẩm được chọn từ ComboBox cb_TenLoai2
                string TruyXuat = "SELECT MaLoai FROM LoaiSP where TenLoai = N'" + cb_TenLoai2.Text + "'";

                // Tạo đối tượng SqlDataAdapter để thực thi truy vấn và điền dữ liệu vào DataTable
                SqlDataAdapter adapter1 = new SqlDataAdapter(TruyXuat, conn);

                // Khởi tạo một DataTable để lưu trữ dữ liệu từ truy vấn
                DataTable data1 = new DataTable();

                // Đổ dữ liệu từ truy vấn vào DataTable
                adapter1.Fill(data1);

                // Lấy giá trị từ ô đầu tiên của hàng đầu tiên trong DataTable (nếu có)
                object cellValue = data1.Rows[0][0];

                // Đặt câu lệnh SQL cho đối tượng SqlCommand để chèn dữ liệu vào bảng XuatKho
                cmd.CommandText = "Insert into XuatKho Values('" + txt_SoPX.Text + "','" + txt_MaNV1.Text + "','" + dateTimePicker2.Text + "','" + cellValue.ToString() + "','" + txt_SoLuong1.Text + "')";

                //thực hiện câu lệnh
                cmd.ExecuteNonQuery();

                // Tạo câu lệnh SQL để truy vấn dữ liệu từ bảng XuatKho và LoaiSP
                //string sqlQuery = "select XuatKho.MaPX, XuatKho.MaNV, LoaiSP.TenLoai, XuatKho.SoLuong from LoaiSP, XuatKho where LoaiSP.MaLoai = XuatKho.MaLoai and XuatKho.MaPX = '" + txt_SoPX.Text + "'";
                string sqlQuery = "select XuatKho.MaPX, XuatKho.MaNV, LoaiSP.TenLoai, XuatKho.SoLuong from LoaiSP, XuatKho where LoaiSP.MaLoai = XuatKho.MaLoai";

                // Tạo một đối tượng SqlDataAdapter để thực thi truy vấn và lấy dữ liệu từ cơ sở dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);

                // Tạo một DataTable để lưu trữ kết quả từ truy vấn
                DataTable data = new DataTable();

                // Xóa tất cả các cột hiện có trong DataGridView
                dataGridView_XuatKho.Columns.Clear();

                // Đổ dữ liệu từ truy vấn vào DataTable
                adapter.Fill(data);

                // Thêm một cột mới vào DataTable để lưu trữ ngày xuất
                data.Columns.Add("Ngày xuất", typeof(string));

                // Đặt giá trị cho cột "Ngày xuất" trong mỗi hàng của DataTable
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["Ngày xuất"] = dateTimePicker2.Text;
                }

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dataGridView_XuatKho.DataSource = data;

                // Đặt tên cho các cột trong DataGridView
                dataGridView_XuatKho.Columns[0].HeaderText = "Số phiếu xuất";
                dataGridView_XuatKho.Columns[1].HeaderText = "Mã nhân viên";
                dataGridView_XuatKho.Columns[2].HeaderText = "Tên loại sản phẩm";
                dataGridView_XuatKho.Columns[3].HeaderText = "Số lượng";
            }
        
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính
                {
                    MessageBox.Show("Mã phiếu xuất đã tồn tại. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Xử lý ngoại lệ ở đây, ví dụ như xóa dữ liệu đã nhập, hoặc yêu cầu người dùng nhập lại mã phiếu xuất.
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Xử lý ngoại lệ SQL khác nếu cần.
                }
            }
        }
    }
}
