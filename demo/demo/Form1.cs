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
    public partial class Form_Main : Form
    {
        
        public bool isThoat = true; // kiem tra thoat
        public string Role = ""; // truyền dữ liệu phân quyền từ form_DangNhap
        public Form_Main(string role)
        {
            InitializeComponent();
            Role = role;
        }
        
        private Form currentFormChild; 

        // tạo hàm để nhượng quyền hiển thị cho form con trong form cha
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm; 
            childForm.TopLevel = false; // ko cho form con hiển thị độc lập với form cha
            childForm.FormBorderStyle = FormBorderStyle.None; //Loại bỏ hộp thoại đóng, thu nhỏ, phóng to
            childForm.Dock = DockStyle.Fill; // lấp đầy panel_body
            panel_body.Controls.Add(childForm); // thêm form con vào danh sách các controls của panel
            panel_body.Tag = childForm;
            childForm.BringToFront(); // đưa form con lên trước form cha
            childForm.Show(); // hiển thị form con
         }

      
        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new fm_LoaiSP());
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // chuỗi kết nối
                String str = "Server=localhost;Database=QLKhoHang;Trusted_Connection=true";
                
                // lệnh truy vấn
                String query = "select * from data";

                SqlConnection con = new SqlConnection(str);

                // thực thị lệnh truy vấn
                SqlCommand cmd = new SqlCommand(query, con);
                
                // mở kết nối
                con.Open();

                DataSet ds = new DataSet();
                MessageBox.Show("Đăng nhập thành công","Thông báo");

                // đóng kết nối
                con.Close();

                // giới hạn quyền nếu là tài khoản user
                if (Role == "User")
                {
                    // ko hiển thị NVToolStripMenuItem1
                    NVToolStripMenuItem1.Visible = false;

                    // ko hiển thị QLTKToolStripMenuItem
                    QLTKToolStripMenuItem.Visible = false;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        
        // khi click vào nút Thống kê
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_ThongKe());
        }

        // khi click vào Đăng xuất
        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close(); // đóng form này lại
            form_Dangnhap f = new form_Dangnhap(); // mở form Đăng nhập mới
            f.Show();// hiển thị lại form đăng nhập
        }

        // sau khi bấm vào nút x trên góc phải màn hình thoát hoàn toàn chương trình
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
            {
                Application.Exit();
            }
               
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // sau khi bấm vào Loại sản phẩm trên thanh menuStrip
        private void loạiSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_LoaiSP());
        }

        // sau khi bấm vào nút Sản phẩm trên thanh menuStrip
        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_SanPham());
        }

        // sau khi bấm vào Nhập kho trên thanh menuStrip
        private void nhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_NhapKho());
        }

        // sau khi bấm vào Xuất kho trên thanh menuStrip
        private void xuấtKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_XuatKho());
        }

        // sau khi bấm vào Nhân viên trên thanh menuStrip
        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_NhanVien());
        }

        // sau khi bấm vào Tài khoản trên thanh menuStrip
        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_TaiKhoan());
        }

        // sau khi bấm vào Trang chủ trên thanh menuStrip
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // nếu form con đang hiện thì đóng form con lại
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

        
    }
}
