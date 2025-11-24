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
    public partial class fm_ThongKe : Form
    {
        public fm_ThongKe()
        {
            InitializeComponent();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=QLKhoHang;Trusted_Connection=true");
            conn.Open();
            try
            {
                if (radioButton_TonKho.Checked)
                {
                    // Nếu RadioButton "Tồn kho" được chọn
                    // Tạo câu truy vấn SQL để lấy thông tin tồn kho của các sản phẩm
                    string sqlQuery = "Select A.TenLoai, SLton = ((select sum(NhapKho.SoLuongNhap) from NhapKho where NhapKho.MaLoai = A.MaLoai)-(select sum(XuatKho.SoLuong) from XuatKho where XuatKho.MaLoai = A.MaLoai))  from LoaiSP A";
                    
                    // Tạo một đối tượng SqlDataAdapter để thực thi truy vấn và lấy dữ liệu từ cơ sở dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    
                    // Tạo một DataTable để lưu trữ kết quả từ truy vấn
                    DataTable data = new DataTable();
                    
                    // Thêm một cột "STT" vào DataTable và đặt nó ở vị trí đầu tiên
                    data.Columns.Add("STT", typeof(int)).SetOrdinal(0);
                    
                    // Xóa tất cả các cột hiện có trong DataGridView
                    dataGridView_ThongKe.Columns.Clear();
                   
                    // Đổ dữ liệu từ truy vấn vào DataTable
                    adapter.Fill(data);
                    
                    // Thêm một cột mới vào DataTable để lưu trữ ngày thống kê
                    data.Columns.Add("Ngày thống kê", typeof(string));
                    
                    // Vòng lặp để gán giá trị cho cột "STT" và cột "Ngày thống kê" trong mỗi hàng của DataTable
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        data.Rows[i]["STT"] = i + 1;
                        data.Rows[i]["Ngày thống kê"] = dateTimePicker6.Text;
                    }
                    
                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dataGridView_ThongKe.DataSource = data;
                    // Đặt tên cho các cột trong DataGridView
                    dataGridView_ThongKe.Columns[1].HeaderText = "Tên loại sản phẩm";
                    dataGridView_ThongKe.Columns[2].HeaderText = "Số lượng tồn";
                }
                if (radioButton_TenloaiSP.Checked)
                {
                    // Nếu RadioButton "Tên loại sản phẩm" được chọn
                    // Tạo câu truy vấn SQL để lấy thông tin tồn kho của sản phẩm được chọn từ ComboBox
                    string query = "Select A.TenLoai, SLton = ((select sum(NhapKho.SoLuongNhap) from NhapKho where NhapKho.MaLoai = A.MaLoai)-(select sum(XuatKho.SoLuong) from XuatKho where XuatKho.MaLoai = A.MaLoai))  from LoaiSP A where A.TenLoai = N'" + cb_TenLoai3.Text + "'";
                    
                    // Tạo một đối tượng SqlDataAdapter để thực thi truy vấn và lấy dữ liệu từ cơ sở dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    
                    // Tạo một DataTable để lưu trữ kết quả từ truy vấn
                    DataTable data = new DataTable();
                    
                    // Thêm một cột "STT" vào DataTable và đặt nó ở vị trí đầu tiên
                    data.Columns.Add("STT", typeof(int)).SetOrdinal(0);
                    
                    // Xóa tất cả các cột hiện có trong DataGridView
                    dataGridView_ThongKe.Columns.Clear();
                    
                    // Đổ dữ liệu từ truy vấn vào DataTable
                    adapter.Fill(data);
                    
                    // Thêm một cột mới vào DataTable để lưu trữ ngày thống kê
                    data.Columns.Add("Ngày thống kê", typeof(string));
                    
                    // Vòng lặp để gán giá trị cho cột "STT" và cột "Ngày thống kê" trong mỗi hàng của DataTable
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        data.Rows[i]["STT"] = i + 1;
                        data.Rows[i]["Ngày thống kê"] = dateTimePicker6.Text;
                    }
                    
                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dataGridView_ThongKe.DataSource = data;
                    // Đặt tên cho các cột trong DataGridView
                    dataGridView_ThongKe.Columns[1].HeaderText = "Tên loại sản phẩm";
                    dataGridView_ThongKe.Columns[2].HeaderText = "Số lượng tồn";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Xử lý ngoại lệ SQL khác nếu cần.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Xử lý ngoại lệ khác nếu cần.
            }
        }

        private void fm_ThongKe_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=QLKhoHang;Trusted_Connection=true");
            conn.Open();
            try
            {
                // Chuỗi truy vấn SQL để lấy danh sách các sản phẩm từ bảng LoaiSP
                string SP = "SELECT TenLoai FROM LoaiSP";

                // Tạo một đối tượng SqlCommand để thực thi truy vấn
                SqlCommand SanPham = new SqlCommand(SP, conn);

                // Thực thi truy vấn và trả về một đối tượng SqlDataReader để đọc dữ liệu từ kết quả truy vấn
                SqlDataReader reader = SanPham.ExecuteReader();

                // Đẩy dữ liệu vào ComboBox
                while (reader.Read()) // Đọc từng dòng dữ liệu một trong SqlDataReader
                {
                    // Thêm dữ liệu từ cột "TenLoai" của kết quả truy vấn vào ComboBox
                    cb_TenLoai3.Items.Add(reader["TenLoai"].ToString());
                }
                // Đóng đối tượng SqlDataReader sau khi đã sử dụng xong
                reader.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra trong quá trình thực thi truy vấn
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Đảm bảo rằng kết nối đến cơ sở dữ liệu được đóng sau khi đã sử dụng xong
                conn.Close();
            }
        }
    }
}
