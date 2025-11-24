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
using demo.logic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demo
{
    public partial class form_Dangnhap : Form
    {
        public form_Dangnhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                //kết nối CSDL
                String str = "Server=localhost;Database=QLKhoHang;Trusted_Connection=true";
                SqlConnection con = new SqlConnection(str);
  
                string tenDN = txt_TenDangNhap.Text.Trim();
                string mk = txt_MatKhau.Text.Trim();
                //câu truy vấn
                string query = "select * from QuanLyTK where TenDN = '"+ txt_TenDangNhap.Text + "'and MK = '" + txt_MatKhau.Text + "'";
                
                // thực thi lệnh truy vấn
                SqlCommand cmd = new SqlCommand(query, con);
                
                // mở kết nối
                con.Open();
                DataSet ds = new DataSet();
                SqlDataReader reader = cmd.ExecuteReader(); // ExecuteReader() được sử dụng khi câu lệnh truy vấn là select

                if (txt_TenDangNhap.Text != string.Empty || txt_MatKhau.Text != string.Empty)
                {
                    if (reader.Read())
                    {
                        // lấy quyền truy cập
                        // Trim(): xóa khoảng trống sau chuỗi đc lấy
                        QuanLyTK taiKhoan = new QuanLyTK(
                            reader["MaNV"].ToString().Trim(),
                            reader["PhanQuyen"].ToString().Trim()
                        );
                        reader.Close();
                       
                        Form_Main fm1 = new Form_Main(taiKhoan.PhanQuyen); // tạo form chính mới
                        fm1.Show(); // hiện form chính
                        this.Hide(); // ẩn form sau khi vào form chính
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Đăng nhập thất bại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Cần nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }
       
        private void form_Dangnhap_Load(object sender, EventArgs e)
        {
           
           
        }

        // hàm hiển thị mật khẩu
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // nếu không chọn hiển thị thì để mặc định là false - không hiển thị
            if (ckB_hienthiMK.Checked)
            {
                txt_MatKhau.UseSystemPasswordChar = false;
            }

            // nếu chọn hiển thị thì trở thành true - hiển thị
            if (!ckB_hienthiMK.Checked)
            {
                txt_MatKhau.UseSystemPasswordChar = true;
            }
        }

        // sau khi nhấn vào dấu x thoát chương trình hoàn toàn
        private void form_Dangnhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
