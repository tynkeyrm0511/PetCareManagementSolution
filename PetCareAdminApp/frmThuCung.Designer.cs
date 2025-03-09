namespace PetCareAdminApp
{
    partial class frmThuCung
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.groupBoxThongTin = new Guna.UI2.WinForms.Guna2Panel();
            this.picThuCung = new System.Windows.Forms.PictureBox();
            this.btnChonHinh = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.cmbChu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTenThuCung = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaThuCung = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvThuCung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.groupBoxThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThuCung)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuCung)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxThongTin.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxThongTin.BorderRadius = 10;
            this.groupBoxThongTin.BorderThickness = 2;
            this.groupBoxThongTin.Controls.Add(this.picThuCung);
            this.groupBoxThongTin.Controls.Add(this.btnChonHinh);
            this.groupBoxThongTin.Controls.Add(this.guna2HtmlLabel2);
            this.groupBoxThongTin.Controls.Add(this.guna2HtmlLabel1);
            this.groupBoxThongTin.Controls.Add(this.guna2Separator1);
            this.groupBoxThongTin.Controls.Add(this.cmbChu);
            this.groupBoxThongTin.Controls.Add(this.cmbLoai);
            this.groupBoxThongTin.Controls.Add(this.txtTenThuCung);
            this.groupBoxThongTin.Controls.Add(this.txtMaThuCung);
            this.groupBoxThongTin.FillColor = System.Drawing.Color.White;
            this.groupBoxThongTin.Location = new System.Drawing.Point(12, 6);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.ShadowDecoration.Parent = this.groupBoxThongTin;
            this.groupBoxThongTin.Size = new System.Drawing.Size(265, 599);
            this.groupBoxThongTin.TabIndex = 8;
            // 
            // picThuCung
            // 
            this.picThuCung.Image = global::PetCareAdminApp.Properties.Resources.car;
            this.picThuCung.Location = new System.Drawing.Point(19, 307);
            this.picThuCung.Name = "picThuCung";
            this.picThuCung.Size = new System.Drawing.Size(230, 230);
            this.picThuCung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThuCung.TabIndex = 19;
            this.picThuCung.TabStop = false;
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.BorderRadius = 10;
            this.btnChonHinh.CheckedState.Parent = this.btnChonHinh;
            this.btnChonHinh.CustomImages.Parent = this.btnChonHinh;
            this.btnChonHinh.Font = new System.Drawing.Font("Playpen Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonHinh.ForeColor = System.Drawing.Color.White;
            this.btnChonHinh.HoverState.Parent = this.btnChonHinh;
            this.btnChonHinh.ImageSize = new System.Drawing.Size(30, 30);
            this.btnChonHinh.Location = new System.Drawing.Point(9, 552);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.ShadowDecoration.Parent = this.btnChonHinh;
            this.btnChonHinh.Size = new System.Drawing.Size(250, 35);
            this.btnChonHinh.TabIndex = 18;
            this.btnChonHinh.Text = "Chọn ảnh thú cưng";
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Playpen Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(107, 229);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(41, 35);
            this.guna2HtmlLabel2.TabIndex = 17;
            this.guna2HtmlLabel2.Text = "Chủ";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Playpen Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(107, 146);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(44, 35);
            this.guna2HtmlLabel1.TabIndex = 16;
            this.guna2HtmlLabel1.Text = "Loại";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(9, 130);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(244, 10);
            this.guna2Separator1.TabIndex = 15;
            // 
            // cmbChu
            // 
            this.cmbChu.BackColor = System.Drawing.Color.Transparent;
            this.cmbChu.BorderRadius = 10;
            this.cmbChu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChu.FocusedColor = System.Drawing.Color.Empty;
            this.cmbChu.FocusedState.Parent = this.cmbChu;
            this.cmbChu.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbChu.FormattingEnabled = true;
            this.cmbChu.HoverState.Parent = this.cmbChu;
            this.cmbChu.ItemHeight = 30;
            this.cmbChu.ItemsAppearance.Parent = this.cmbChu;
            this.cmbChu.Location = new System.Drawing.Point(15, 265);
            this.cmbChu.Name = "cmbChu";
            this.cmbChu.ShadowDecoration.Parent = this.cmbChu;
            this.cmbChu.Size = new System.Drawing.Size(239, 36);
            this.cmbChu.TabIndex = 14;
            // 
            // cmbLoai
            // 
            this.cmbLoai.BackColor = System.Drawing.Color.Transparent;
            this.cmbLoai.BorderRadius = 10;
            this.cmbLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FocusedColor = System.Drawing.Color.Empty;
            this.cmbLoai.FocusedState.Parent = this.cmbLoai;
            this.cmbLoai.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.HoverState.Parent = this.cmbLoai;
            this.cmbLoai.ItemHeight = 30;
            this.cmbLoai.ItemsAppearance.Parent = this.cmbLoai;
            this.cmbLoai.Location = new System.Drawing.Point(15, 187);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.ShadowDecoration.Parent = this.cmbLoai;
            this.cmbLoai.Size = new System.Drawing.Size(239, 36);
            this.cmbLoai.TabIndex = 13;
            // 
            // txtTenThuCung
            // 
            this.txtTenThuCung.BorderRadius = 10;
            this.txtTenThuCung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenThuCung.DefaultText = "";
            this.txtTenThuCung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenThuCung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenThuCung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenThuCung.DisabledState.Parent = this.txtTenThuCung;
            this.txtTenThuCung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenThuCung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenThuCung.FocusedState.Parent = this.txtTenThuCung;
            this.txtTenThuCung.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThuCung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenThuCung.HoverState.Parent = this.txtTenThuCung;
            this.txtTenThuCung.Location = new System.Drawing.Point(12, 75);
            this.txtTenThuCung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenThuCung.Name = "txtTenThuCung";
            this.txtTenThuCung.PasswordChar = '\0';
            this.txtTenThuCung.PlaceholderText = "Tên thú cưng";
            this.txtTenThuCung.SelectedText = "";
            this.txtTenThuCung.ShadowDecoration.Parent = this.txtTenThuCung;
            this.txtTenThuCung.Size = new System.Drawing.Size(239, 50);
            this.txtTenThuCung.TabIndex = 7;
            // 
            // txtMaThuCung
            // 
            this.txtMaThuCung.BorderRadius = 10;
            this.txtMaThuCung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaThuCung.DefaultText = "";
            this.txtMaThuCung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaThuCung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaThuCung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaThuCung.DisabledState.Parent = this.txtMaThuCung;
            this.txtMaThuCung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaThuCung.Enabled = false;
            this.txtMaThuCung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaThuCung.FocusedState.Parent = this.txtMaThuCung;
            this.txtMaThuCung.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThuCung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaThuCung.HoverState.Parent = this.txtMaThuCung;
            this.txtMaThuCung.Location = new System.Drawing.Point(12, 21);
            this.txtMaThuCung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaThuCung.Name = "txtMaThuCung";
            this.txtMaThuCung.PasswordChar = '\0';
            this.txtMaThuCung.PlaceholderText = "Mã thú cưng";
            this.txtMaThuCung.SelectedText = "";
            this.txtMaThuCung.ShadowDecoration.Parent = this.txtMaThuCung;
            this.txtMaThuCung.Size = new System.Drawing.Size(239, 50);
            this.txtMaThuCung.TabIndex = 6;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.dgvThuCung);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(283, 62);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(697, 543);
            this.guna2Panel2.TabIndex = 9;
            // 
            // dgvThuCung
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThuCung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThuCung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuCung.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuCung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThuCung.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThuCung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThuCung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThuCung.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThuCung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThuCung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThuCung.EnableHeadersVisualStyles = false;
            this.dgvThuCung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThuCung.Location = new System.Drawing.Point(0, 0);
            this.dgvThuCung.Name = "dgvThuCung";
            this.dgvThuCung.RowHeadersVisible = false;
            this.dgvThuCung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuCung.Size = new System.Drawing.Size(697, 543);
            this.dgvThuCung.TabIndex = 0;
            this.dgvThuCung.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvThuCung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThuCung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThuCung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThuCung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThuCung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThuCung.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThuCung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThuCung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThuCung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThuCung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvThuCung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThuCung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThuCung.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvThuCung.ThemeStyle.ReadOnly = false;
            this.dgvThuCung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThuCung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThuCung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvThuCung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThuCung.ThemeStyle.RowsStyle.Height = 22;
            this.dgvThuCung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThuCung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThuCung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuCung_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 10;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.Parent = this.txtTimKiem;
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.FocusedState.Parent = this.txtTimKiem;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.HoverState.Parent = this.txtTimKiem;
            this.txtTimKiem.Location = new System.Drawing.Point(452, 6);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "Nhập tên thú cưng cần tìm kiếm...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.ShadowDecoration.Parent = this.txtTimKiem;
            this.txtTimKiem.Size = new System.Drawing.Size(473, 50);
            this.txtTimKiem.TabIndex = 13;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.CheckedState.Parent = this.btnTimKiem;
            this.btnTimKiem.CustomImages.Parent = this.btnTimKiem;
            this.btnTimKiem.FillColor = System.Drawing.Color.Orange;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.HoverState.Parent = this.btnTimKiem;
            this.btnTimKiem.Image = global::PetCareAdminApp.Properties.Resources.search_alt;
            this.btnTimKiem.ImageSize = new System.Drawing.Size(40, 40);
            this.btnTimKiem.Location = new System.Drawing.Point(931, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.ShadowDecoration.Parent = this.btnTimKiem;
            this.btnTimKiem.Size = new System.Drawing.Size(50, 50);
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.CheckedState.Parent = this.btnXoa;
            this.btnXoa.CustomImages.Parent = this.btnXoa;
            this.btnXoa.FillColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.HoverState.Parent = this.btnXoa;
            this.btnXoa.Image = global::PetCareAdminApp.Properties.Resources.delete;
            this.btnXoa.ImageSize = new System.Drawing.Size(40, 40);
            this.btnXoa.Location = new System.Drawing.Point(396, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ShadowDecoration.Parent = this.btnXoa;
            this.btnXoa.Size = new System.Drawing.Size(50, 50);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 10;
            this.btnThem.CheckedState.Parent = this.btnThem;
            this.btnThem.CustomImages.Parent = this.btnThem;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.HoverState.Parent = this.btnThem;
            this.btnThem.Image = global::PetCareAdminApp.Properties.Resources.multiple;
            this.btnThem.ImageSize = new System.Drawing.Size(40, 40);
            this.btnThem.Location = new System.Drawing.Point(284, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShadowDecoration.Parent = this.btnThem;
            this.btnThem.Size = new System.Drawing.Size(50, 50);
            this.btnThem.TabIndex = 11;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 10;
            this.btnSua.CheckedState.Parent = this.btnSua;
            this.btnSua.CustomImages.Parent = this.btnSua;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(169)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.Parent = this.btnSua;
            this.btnSua.Image = global::PetCareAdminApp.Properties.Resources.edit;
            this.btnSua.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSua.Location = new System.Drawing.Point(340, 6);
            this.btnSua.Name = "btnSua";
            this.btnSua.ShadowDecoration.Parent = this.btnSua;
            this.btnSua.Size = new System.Drawing.Size(50, 50);
            this.btnSua.TabIndex = 10;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmThuCung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(217)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(992, 617);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.groupBoxThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThuCung";
            this.Text = "frmThuCung";
            this.Load += new System.EventHandler(this.frmThuCung_Load);
            this.groupBoxThongTin.ResumeLayout(false);
            this.groupBoxThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThuCung)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuCung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel groupBoxThongTin;
        private Guna.UI2.WinForms.Guna2TextBox txtTenThuCung;
        private Guna.UI2.WinForms.Guna2TextBox txtMaThuCung;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThuCung;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLoai;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnChonHinh;
        private System.Windows.Forms.PictureBox picThuCung;
    }
}