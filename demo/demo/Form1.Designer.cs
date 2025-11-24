namespace demo
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMuctoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiSảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtKhoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GioiThieuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ĐangxuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_body = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel_body.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.danhMuctoolStripMenuItem1,
            this.thốngKêToolStripMenuItem,
            this.QLTKToolStripMenuItem,
            this.GioiThieuToolStripMenuItem,
            this.ĐangxuatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Image = global::demo.Properties.Resources.trangchu;
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(109, 25);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            this.trangChủToolStripMenuItem.Click += new System.EventHandler(this.trangChủToolStripMenuItem_Click);
            // 
            // danhMuctoolStripMenuItem1
            // 
            this.danhMuctoolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loạiSảnPhẩmToolStripMenuItem1,
            this.sảnPhẩmToolStripMenuItem1,
            this.nhậpKhoToolStripMenuItem1,
            this.xuấtKhoToolStripMenuItem1,
            this.NVToolStripMenuItem1});
            this.danhMuctoolStripMenuItem1.Image = global::demo.Properties.Resources.danhsach;
            this.danhMuctoolStripMenuItem1.Name = "danhMuctoolStripMenuItem1";
            this.danhMuctoolStripMenuItem1.ShowShortcutKeys = false;
            this.danhMuctoolStripMenuItem1.Size = new System.Drawing.Size(110, 25);
            this.danhMuctoolStripMenuItem1.Text = "Danh mục";
            // 
            // loạiSảnPhẩmToolStripMenuItem1
            // 
            this.loạiSảnPhẩmToolStripMenuItem1.Image = global::demo.Properties.Resources.Loaisp;
            this.loạiSảnPhẩmToolStripMenuItem1.Name = "loạiSảnPhẩmToolStripMenuItem1";
            this.loạiSảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.loạiSảnPhẩmToolStripMenuItem1.Text = "Loại sản phẩm";
            this.loạiSảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.loạiSảnPhẩmToolStripMenuItem1_Click);
            // 
            // sảnPhẩmToolStripMenuItem1
            // 
            this.sảnPhẩmToolStripMenuItem1.Image = global::demo.Properties.Resources.sp;
            this.sảnPhẩmToolStripMenuItem1.Name = "sảnPhẩmToolStripMenuItem1";
            this.sảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.sảnPhẩmToolStripMenuItem1.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem1_Click);
            // 
            // nhậpKhoToolStripMenuItem1
            // 
            this.nhậpKhoToolStripMenuItem1.Image = global::demo.Properties.Resources.nhap;
            this.nhậpKhoToolStripMenuItem1.Name = "nhậpKhoToolStripMenuItem1";
            this.nhậpKhoToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.nhậpKhoToolStripMenuItem1.Text = "Nhập kho";
            this.nhậpKhoToolStripMenuItem1.Click += new System.EventHandler(this.nhậpKhoToolStripMenuItem1_Click);
            // 
            // xuấtKhoToolStripMenuItem1
            // 
            this.xuấtKhoToolStripMenuItem1.Image = global::demo.Properties.Resources.Xuatkho;
            this.xuấtKhoToolStripMenuItem1.Name = "xuấtKhoToolStripMenuItem1";
            this.xuấtKhoToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.xuấtKhoToolStripMenuItem1.Text = "Xuất kho";
            this.xuấtKhoToolStripMenuItem1.Click += new System.EventHandler(this.xuấtKhoToolStripMenuItem1_Click);
            // 
            // NVToolStripMenuItem1
            // 
            this.NVToolStripMenuItem1.Image = global::demo.Properties.Resources.Nhanvien;
            this.NVToolStripMenuItem1.Name = "NVToolStripMenuItem1";
            this.NVToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.NVToolStripMenuItem1.Text = "Nhân viên";
            this.NVToolStripMenuItem1.Click += new System.EventHandler(this.nhânViênToolStripMenuItem1_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Image = global::demo.Properties.Resources.thongke;
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.ShowShortcutKeys = false;
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(106, 25);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // QLTKToolStripMenuItem
            // 
            this.QLTKToolStripMenuItem.Image = global::demo.Properties.Resources.tk;
            this.QLTKToolStripMenuItem.Name = "QLTKToolStripMenuItem";
            this.QLTKToolStripMenuItem.Size = new System.Drawing.Size(105, 25);
            this.QLTKToolStripMenuItem.Text = "Tài khoản";
            this.QLTKToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // GioiThieuToolStripMenuItem
            // 
            this.GioiThieuToolStripMenuItem.Image = global::demo.Properties.Resources.gioithieu;
            this.GioiThieuToolStripMenuItem.Name = "GioiThieuToolStripMenuItem";
            this.GioiThieuToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.GioiThieuToolStripMenuItem.Text = "Giới thiệu";
            // 
            // ĐangxuatToolStripMenuItem
            // 
            this.ĐangxuatToolStripMenuItem.Name = "ĐangxuatToolStripMenuItem";
            this.ĐangxuatToolStripMenuItem.Size = new System.Drawing.Size(95, 25);
            this.ĐangxuatToolStripMenuItem.Text = "Đăng xuất";
            this.ĐangxuatToolStripMenuItem.Click += new System.EventHandler(this.giớiThiệuToolStripMenuItem_Click);
            // 
            // panel_body
            // 
            this.panel_body.BackgroundImage = global::demo.Properties.Resources.kho_bai;
            this.panel_body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_body.Controls.Add(this.label1);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 29);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(800, 421);
            this.panel_body.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(61, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chào mừng bạn đến với ứng dụng quản lý kho hàng của chúng tôi!";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý kho hàng - Nhóm 9";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_body.ResumeLayout(false);
            this.panel_body.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GioiThieuToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ĐangxuatToolStripMenuItem;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.ToolStripMenuItem danhMuctoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loạiSảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xuấtKhoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem NVToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
    }
}