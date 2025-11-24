namespace demo
{
    partial class fm_ThongKe
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.radioButton_TonKho = new System.Windows.Forms.RadioButton();
            this.radioButton_TenloaiSP = new System.Windows.Forms.RadioButton();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.cb_TenLoai3 = new System.Windows.Forms.ComboBox();
            this.dataGridView_ThongKe = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.radioButton_TonKho);
            this.panel9.Controls.Add(this.radioButton_TenloaiSP);
            this.panel9.Controls.Add(this.btn_ThongKe);
            this.panel9.Controls.Add(this.dateTimePicker6);
            this.panel9.Controls.Add(this.label31);
            this.panel9.Controls.Add(this.cb_TenLoai3);
            this.panel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(3, 58);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1194, 126);
            this.panel9.TabIndex = 1;
            // 
            // radioButton_TonKho
            // 
            this.radioButton_TonKho.AutoSize = true;
            this.radioButton_TonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_TonKho.Location = new System.Drawing.Point(54, 74);
            this.radioButton_TonKho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_TonKho.Name = "radioButton_TonKho";
            this.radioButton_TonKho.Size = new System.Drawing.Size(205, 24);
            this.radioButton_TonKho.TabIndex = 8;
            this.radioButton_TonKho.TabStop = true;
            this.radioButton_TonKho.Text = "Danh sách sản phẩm tồn";
            this.radioButton_TonKho.UseVisualStyleBackColor = true;
            // 
            // radioButton_TenloaiSP
            // 
            this.radioButton_TenloaiSP.AutoSize = true;
            this.radioButton_TenloaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_TenloaiSP.Location = new System.Drawing.Point(54, 22);
            this.radioButton_TenloaiSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_TenloaiSP.Name = "radioButton_TenloaiSP";
            this.radioButton_TenloaiSP.Size = new System.Drawing.Size(156, 24);
            this.radioButton_TenloaiSP.TabIndex = 7;
            this.radioButton_TenloaiSP.TabStop = true;
            this.radioButton_TenloaiSP.Text = "Tên loại sản phẩm";
            this.radioButton_TenloaiSP.UseVisualStyleBackColor = true;
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongKe.Location = new System.Drawing.Point(933, 28);
            this.btn_ThongKe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(117, 72);
            this.btn_ThongKe.TabIndex = 6;
            this.btn_ThongKe.Text = "Thống kê";
            this.btn_ThongKe.UseVisualStyleBackColor = false;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker6.Location = new System.Drawing.Point(642, 48);
            this.dateTimePicker6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(116, 26);
            this.dateTimePicker6.TabIndex = 4;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(513, 54);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(115, 20);
            this.label31.TabIndex = 3;
            this.label31.Text = "Ngày thống kê ";
            // 
            // cb_TenLoai3
            // 
            this.cb_TenLoai3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_TenLoai3.FormattingEnabled = true;
            this.cb_TenLoai3.Location = new System.Drawing.Point(261, 21);
            this.cb_TenLoai3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_TenLoai3.Name = "cb_TenLoai3";
            this.cb_TenLoai3.Size = new System.Drawing.Size(180, 28);
            this.cb_TenLoai3.TabIndex = 2;
            // 
            // dataGridView_ThongKe
            // 
            this.dataGridView_ThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView_ThongKe.Location = new System.Drawing.Point(3, 194);
            this.dataGridView_ThongKe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_ThongKe.Name = "dataGridView_ThongKe";
            this.dataGridView_ThongKe.Size = new System.Drawing.Size(1194, 495);
            this.dataGridView_ThongKe.TabIndex = 2;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên loại sản phẩm";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Số lượng tồn";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ngày thống kê ";
            this.Column3.Name = "Column3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thống kê";
            // 
            // fm_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ThongKe);
            this.Controls.Add(this.panel9);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fm_ThongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.fm_ThongKe_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton radioButton_TonKho;
        private System.Windows.Forms.RadioButton radioButton_TenloaiSP;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cb_TenLoai3;
        private System.Windows.Forms.DataGridView dataGridView_ThongKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
    }
}