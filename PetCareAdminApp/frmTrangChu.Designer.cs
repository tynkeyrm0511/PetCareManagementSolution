namespace PetCareAdminApp
{
    partial class frmTrangChu
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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblThoiGian = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnMoFormChat = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMoFormLichHen = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMoFormDichVu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMoFormThuCung = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMoFormKhachHang = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timerThoiGian = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.BorderRadius = 5;
            this.panelMain.BorderThickness = 3;
            this.panelMain.Controls.Add(this.lblThoiGian);
            this.panelMain.CustomBorderThickness = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panelMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(217)))), ((int)(((byte)(222)))));
            this.panelMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panelMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.panelMain.Location = new System.Drawing.Point(274, 13);
            this.panelMain.Name = "panelMain";
            this.panelMain.ShadowDecoration.Parent = this.panelMain;
            this.panelMain.Size = new System.Drawing.Size(1150, 702);
            this.panelMain.TabIndex = 1;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.BackColor = System.Drawing.Color.Transparent;
            this.lblThoiGian.Font = new System.Drawing.Font("Playpen Sans", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(169)))));
            this.lblThoiGian.Location = new System.Drawing.Point(42, 223);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(107, 167);
            this.lblThoiGian.TabIndex = 0;
            this.lblThoiGian.Text = "....";
            this.lblThoiGian.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMoFormChat
            // 
            this.btnMoFormChat.BorderColor = System.Drawing.Color.White;
            this.btnMoFormChat.BorderRadius = 20;
            this.btnMoFormChat.BorderThickness = 4;
            this.btnMoFormChat.CheckedState.Parent = this.btnMoFormChat;
            this.btnMoFormChat.CustomImages.Parent = this.btnMoFormChat;
            this.btnMoFormChat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormChat.Font = new System.Drawing.Font("Playpen Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoFormChat.ForeColor = System.Drawing.Color.White;
            this.btnMoFormChat.HoverState.Parent = this.btnMoFormChat;
            this.btnMoFormChat.Image = global::PetCareAdminApp.Properties.Resources.message;
            this.btnMoFormChat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMoFormChat.ImageSize = new System.Drawing.Size(55, 55);
            this.btnMoFormChat.Location = new System.Drawing.Point(13, 629);
            this.btnMoFormChat.Name = "btnMoFormChat";
            this.btnMoFormChat.ShadowDecoration.Parent = this.btnMoFormChat;
            this.btnMoFormChat.Size = new System.Drawing.Size(256, 83);
            this.btnMoFormChat.TabIndex = 7;
            this.btnMoFormChat.Text = "Chat";
            this.btnMoFormChat.Click += new System.EventHandler(this.btnMoFormChat_Click);
            // 
            // btnMoFormLichHen
            // 
            this.btnMoFormLichHen.BorderColor = System.Drawing.Color.White;
            this.btnMoFormLichHen.BorderRadius = 20;
            this.btnMoFormLichHen.BorderThickness = 4;
            this.btnMoFormLichHen.CheckedState.Parent = this.btnMoFormLichHen;
            this.btnMoFormLichHen.CustomImages.Parent = this.btnMoFormLichHen;
            this.btnMoFormLichHen.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormLichHen.Font = new System.Drawing.Font("Playpen Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoFormLichHen.ForeColor = System.Drawing.Color.White;
            this.btnMoFormLichHen.HoverState.Parent = this.btnMoFormLichHen;
            this.btnMoFormLichHen.Image = global::PetCareAdminApp.Properties.Resources.calendar;
            this.btnMoFormLichHen.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMoFormLichHen.ImageSize = new System.Drawing.Size(55, 55);
            this.btnMoFormLichHen.Location = new System.Drawing.Point(13, 540);
            this.btnMoFormLichHen.Name = "btnMoFormLichHen";
            this.btnMoFormLichHen.ShadowDecoration.Parent = this.btnMoFormLichHen;
            this.btnMoFormLichHen.Size = new System.Drawing.Size(256, 83);
            this.btnMoFormLichHen.TabIndex = 6;
            this.btnMoFormLichHen.Text = "  Lịch hẹn";
            this.btnMoFormLichHen.Click += new System.EventHandler(this.btnMoFormLichHen_Click);
            // 
            // btnMoFormDichVu
            // 
            this.btnMoFormDichVu.BorderColor = System.Drawing.Color.White;
            this.btnMoFormDichVu.BorderRadius = 20;
            this.btnMoFormDichVu.BorderThickness = 4;
            this.btnMoFormDichVu.CheckedState.Parent = this.btnMoFormDichVu;
            this.btnMoFormDichVu.CustomImages.Parent = this.btnMoFormDichVu;
            this.btnMoFormDichVu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormDichVu.Font = new System.Drawing.Font("Playpen Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoFormDichVu.ForeColor = System.Drawing.Color.White;
            this.btnMoFormDichVu.HoverState.Parent = this.btnMoFormDichVu;
            this.btnMoFormDichVu.Image = global::PetCareAdminApp.Properties.Resources.bathing;
            this.btnMoFormDichVu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMoFormDichVu.ImageSize = new System.Drawing.Size(55, 55);
            this.btnMoFormDichVu.Location = new System.Drawing.Point(13, 451);
            this.btnMoFormDichVu.Name = "btnMoFormDichVu";
            this.btnMoFormDichVu.ShadowDecoration.Parent = this.btnMoFormDichVu;
            this.btnMoFormDichVu.Size = new System.Drawing.Size(256, 83);
            this.btnMoFormDichVu.TabIndex = 5;
            this.btnMoFormDichVu.Text = "  Dịch vụ";
            this.btnMoFormDichVu.Click += new System.EventHandler(this.btnMoFormDichVu_Click);
            // 
            // btnMoFormThuCung
            // 
            this.btnMoFormThuCung.BorderColor = System.Drawing.Color.White;
            this.btnMoFormThuCung.BorderRadius = 20;
            this.btnMoFormThuCung.BorderThickness = 4;
            this.btnMoFormThuCung.CheckedState.Parent = this.btnMoFormThuCung;
            this.btnMoFormThuCung.CustomImages.Parent = this.btnMoFormThuCung;
            this.btnMoFormThuCung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormThuCung.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormThuCung.Font = new System.Drawing.Font("Playpen Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoFormThuCung.ForeColor = System.Drawing.Color.White;
            this.btnMoFormThuCung.HoverState.Parent = this.btnMoFormThuCung;
            this.btnMoFormThuCung.Image = global::PetCareAdminApp.Properties.Resources.car;
            this.btnMoFormThuCung.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMoFormThuCung.ImageSize = new System.Drawing.Size(55, 55);
            this.btnMoFormThuCung.Location = new System.Drawing.Point(13, 362);
            this.btnMoFormThuCung.Name = "btnMoFormThuCung";
            this.btnMoFormThuCung.ShadowDecoration.Parent = this.btnMoFormThuCung;
            this.btnMoFormThuCung.Size = new System.Drawing.Size(256, 83);
            this.btnMoFormThuCung.TabIndex = 4;
            this.btnMoFormThuCung.Text = "    Thú cưng";
            this.btnMoFormThuCung.Click += new System.EventHandler(this.btnMoFormThuCung_Click);
            // 
            // btnMoFormKhachHang
            // 
            this.btnMoFormKhachHang.BorderColor = System.Drawing.Color.White;
            this.btnMoFormKhachHang.BorderRadius = 20;
            this.btnMoFormKhachHang.BorderThickness = 4;
            this.btnMoFormKhachHang.CheckedState.Parent = this.btnMoFormKhachHang;
            this.btnMoFormKhachHang.CustomImages.Parent = this.btnMoFormKhachHang;
            this.btnMoFormKhachHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormKhachHang.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnMoFormKhachHang.Font = new System.Drawing.Font("Playpen Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoFormKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnMoFormKhachHang.HoverState.Parent = this.btnMoFormKhachHang;
            this.btnMoFormKhachHang.Image = global::PetCareAdminApp.Properties.Resources.shipping;
            this.btnMoFormKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMoFormKhachHang.ImageSize = new System.Drawing.Size(55, 55);
            this.btnMoFormKhachHang.Location = new System.Drawing.Point(13, 274);
            this.btnMoFormKhachHang.Name = "btnMoFormKhachHang";
            this.btnMoFormKhachHang.ShadowDecoration.Parent = this.btnMoFormKhachHang;
            this.btnMoFormKhachHang.Size = new System.Drawing.Size(256, 83);
            this.btnMoFormKhachHang.TabIndex = 3;
            this.btnMoFormKhachHang.Text = "        Khách hàng";
            this.btnMoFormKhachHang.Click += new System.EventHandler(this.btnMoFormKhachHang_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::PetCareAdminApp.Properties.Resources.cat;
            this.guna2PictureBox1.Location = new System.Drawing.Point(13, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(255, 255);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // timerThoiGian
            // 
            this.timerThoiGian.Tick += new System.EventHandler(this.timerThoiGian_Tick);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1436, 727);
            this.Controls.Add(this.btnMoFormChat);
            this.Controls.Add(this.btnMoFormLichHen);
            this.Controls.Add(this.btnMoFormDichVu);
            this.Controls.Add(this.btnMoFormThuCung);
            this.Controls.Add(this.btnMoFormKhachHang);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrangChu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTrangChu_FormClosing);
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox panelMain;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnMoFormKhachHang;
        private Guna.UI2.WinForms.Guna2GradientButton btnMoFormThuCung;
        private Guna.UI2.WinForms.Guna2GradientButton btnMoFormDichVu;
        private Guna.UI2.WinForms.Guna2GradientButton btnMoFormLichHen;
        private Guna.UI2.WinForms.Guna2GradientButton btnMoFormChat;
        private System.Windows.Forms.Timer timerThoiGian;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblThoiGian;
    }
}