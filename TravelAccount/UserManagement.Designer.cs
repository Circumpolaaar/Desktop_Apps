namespace TravelAccount
{
    partial class UserManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Partner = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GoBack = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Name1 = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.PartnerDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Password1 = new System.Windows.Forms.TextBox();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Partner
            // 
            this.Partner.AutoSize = true;
            this.Partner.BackColor = System.Drawing.Color.Transparent;
            this.Partner.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Partner.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Partner.Location = new System.Drawing.Point(207, 28);
            this.Partner.Name = "Partner";
            this.Partner.Size = new System.Drawing.Size(173, 37);
            this.Partner.TabIndex = 16;
            this.Partner.Text = "账户管理";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(559, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 48);
            this.label5.TabIndex = 17;
            this.label5.Text = "x";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // GoBack
            // 
            this.GoBack.AutoSize = true;
            this.GoBack.Font = new System.Drawing.Font("微软雅黑", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GoBack.ForeColor = System.Drawing.Color.RoyalBlue;
            this.GoBack.Location = new System.Drawing.Point(30, 21);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(47, 48);
            this.GoBack.TabIndex = 18;
            this.GoBack.Text = "<";
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(102, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 20;
            this.label2.Text = "账户";
            // 
            // Name1
            // 
            this.Name1.Location = new System.Drawing.Point(290, 151);
            this.Name1.Margin = new System.Windows.Forms.Padding(4);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(212, 35);
            this.Name1.TabIndex = 19;
            this.Name1.TextChanged += new System.EventHandler(this.BookTitleTb_TextChanged);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.RoyalBlue;
            this.Add.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(38, 298);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(127, 52);
            this.Add.TabIndex = 21;
            this.Add.Text = "添加";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.RoyalBlue;
            this.Delete.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(445, 298);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(127, 52);
            this.Delete.TabIndex = 22;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.RoyalBlue;
            this.Edit.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Edit.ForeColor = System.Drawing.Color.White;
            this.Edit.Location = new System.Drawing.Point(241, 298);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(127, 52);
            this.Edit.TabIndex = 23;
            this.Edit.Text = "编辑";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // PartnerDGV
            // 
            this.PartnerDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartnerDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PartnerDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PartnerDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PartnerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartnerDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column6,
            this.Column1});
            this.PartnerDGV.EnableHeadersVisualStyles = false;
            this.PartnerDGV.GridColor = System.Drawing.Color.Black;
            this.PartnerDGV.Location = new System.Drawing.Point(32, 398);
            this.PartnerDGV.Margin = new System.Windows.Forms.Padding(4);
            this.PartnerDGV.Name = "PartnerDGV";
            this.PartnerDGV.ReadOnly = true;
            this.PartnerDGV.RowHeadersVisible = false;
            this.PartnerDGV.RowHeadersWidth = 82;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.PartnerDGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.PartnerDGV.RowTemplate.Height = 37;
            this.PartnerDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartnerDGV.Size = new System.Drawing.Size(540, 444);
            this.PartnerDGV.TabIndex = 24;
            this.PartnerDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartnerDGV_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(102, 223);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "密码";
            // 
            // Password1
            // 
            this.Password1.Location = new System.Drawing.Point(290, 227);
            this.Password1.Margin = new System.Windows.Forms.Padding(4);
            this.Password1.Name = "Password1";
            this.Password1.Size = new System.Drawing.Size(212, 35);
            this.Password1.TabIndex = 25;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserId";
            this.Column2.HeaderText = "编号";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "UserName";
            this.Column6.HeaderText = "账户";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UserPassword";
            this.Column1.HeaderText = "密码";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 876);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password1);
            this.Controls.Add(this.PartnerDGV);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Name1);
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Partner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PartnerManagement";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Partner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label GoBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Name1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.DataGridView PartnerDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}