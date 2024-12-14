namespace TravelAccount
{
    partial class HomePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Charge = new System.Windows.Forms.Label();
            this.Pay = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Label();
            this.ConsumptionDGV = new System.Windows.Forms.DataGridView();
            this.Consumption = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NowAccount = new System.Windows.Forms.Label();
            this.NowUser = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumptionDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(196, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "切换账本";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.Charge);
            this.panel1.Controls.Add(this.Pay);
            this.panel1.Controls.Add(this.Total);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(47, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1254, 188);
            this.panel1.TabIndex = 13;
            // 
            // Charge
            // 
            this.Charge.AutoSize = true;
            this.Charge.BackColor = System.Drawing.Color.Transparent;
            this.Charge.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Charge.ForeColor = System.Drawing.Color.White;
            this.Charge.Location = new System.Drawing.Point(913, 112);
            this.Charge.Name = "Charge";
            this.Charge.Size = new System.Drawing.Size(136, 37);
            this.Charge.TabIndex = 19;
            this.Charge.Text = "￥0.00";
            // 
            // Pay
            // 
            this.Pay.AutoSize = true;
            this.Pay.BackColor = System.Drawing.Color.Transparent;
            this.Pay.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pay.ForeColor = System.Drawing.Color.White;
            this.Pay.Location = new System.Drawing.Point(550, 112);
            this.Pay.Name = "Pay";
            this.Pay.Size = new System.Drawing.Size(136, 37);
            this.Pay.TabIndex = 18;
            this.Pay.Text = "￥0.00";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.BackColor = System.Drawing.Color.Transparent;
            this.Total.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Total.ForeColor = System.Drawing.Color.White;
            this.Total.Location = new System.Drawing.Point(167, 112);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(136, 37);
            this.Total.TabIndex = 17;
            this.Total.Text = "￥0.00";
            this.Total.Click += new System.EventHandler(this.Total_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(897, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 37);
            this.label4.TabIndex = 16;
            this.label4.Text = "我的应收";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(529, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "我的付款";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(167, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "我的消费";
            // 
            // Calculate
            // 
            this.Calculate.AutoSize = true;
            this.Calculate.BackColor = System.Drawing.Color.Transparent;
            this.Calculate.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Calculate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Calculate.Location = new System.Drawing.Point(944, 329);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(173, 37);
            this.Calculate.TabIndex = 16;
            this.Calculate.Text = "分类查询";
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // ConsumptionDGV
            // 
            this.ConsumptionDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConsumptionDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ConsumptionDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ConsumptionDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ConsumptionDGV.ColumnHeadersHeight = 46;
            this.ConsumptionDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Participant,
            this.Tips});
            this.ConsumptionDGV.EnableHeadersVisualStyles = false;
            this.ConsumptionDGV.GridColor = System.Drawing.Color.RoyalBlue;
            this.ConsumptionDGV.Location = new System.Drawing.Point(47, 401);
            this.ConsumptionDGV.Margin = new System.Windows.Forms.Padding(4);
            this.ConsumptionDGV.Name = "ConsumptionDGV";
            this.ConsumptionDGV.ReadOnly = true;
            this.ConsumptionDGV.RowHeadersVisible = false;
            this.ConsumptionDGV.RowHeadersWidth = 82;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.ConsumptionDGV.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ConsumptionDGV.RowTemplate.Height = 37;
            this.ConsumptionDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConsumptionDGV.Size = new System.Drawing.Size(1258, 446);
            this.ConsumptionDGV.TabIndex = 19;
            this.ConsumptionDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConsumptionDGV_CellContentClick);
            // 
            // Consumption
            // 
            this.Consumption.AutoSize = true;
            this.Consumption.BackColor = System.Drawing.Color.Transparent;
            this.Consumption.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Consumption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Consumption.Location = new System.Drawing.Point(579, 329);
            this.Consumption.Name = "Consumption";
            this.Consumption.Size = new System.Drawing.Size(173, 37);
            this.Consumption.TabIndex = 21;
            this.Consumption.Text = "添加账目";
            this.Consumption.Click += new System.EventHandler(this.Consumption_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(1299, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 48);
            this.label5.TabIndex = 22;
            this.label5.Text = "x";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NowAccount
            // 
            this.NowAccount.AutoSize = true;
            this.NowAccount.BackColor = System.Drawing.Color.Transparent;
            this.NowAccount.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NowAccount.ForeColor = System.Drawing.Color.RoyalBlue;
            this.NowAccount.Location = new System.Drawing.Point(743, 30);
            this.NowAccount.Name = "NowAccount";
            this.NowAccount.Size = new System.Drawing.Size(181, 40);
            this.NowAccount.TabIndex = 23;
            this.NowAccount.Text = "当前帐本";
            this.NowAccount.Click += new System.EventHandler(this.NowAccount_Click);
            // 
            // NowUser
            // 
            this.NowUser.AutoSize = true;
            this.NowUser.BackColor = System.Drawing.Color.Transparent;
            this.NowUser.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NowUser.ForeColor = System.Drawing.Color.RoyalBlue;
            this.NowUser.Location = new System.Drawing.Point(395, 30);
            this.NowUser.Name = "NowUser";
            this.NowUser.Size = new System.Drawing.Size(181, 40);
            this.NowUser.TabIndex = 24;
            this.NowUser.Text = "当前用户";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CId";
            this.Column4.HeaderText = "消费编号";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "CCategory";
            this.Column6.HeaderText = "类型";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CPrice";
            this.Column1.HeaderText = "金额";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CPayer";
            this.Column2.HeaderText = "付款人";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Date";
            this.Column3.HeaderText = "日期";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Participant
            // 
            this.Participant.DataPropertyName = "CParticipant";
            this.Participant.HeaderText = "参与人";
            this.Participant.MinimumWidth = 10;
            this.Participant.Name = "Participant";
            this.Participant.ReadOnly = true;
            // 
            // Tips
            // 
            this.Tips.DataPropertyName = "CTips";
            this.Tips.HeaderText = "备注";
            this.Tips.MinimumWidth = 10;
            this.Tips.Name = "Tips";
            this.Tips.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.RoyalBlue;
            this.Delete.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(797, 867);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(127, 52);
            this.Delete.TabIndex = 34;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.RoyalBlue;
            this.Edit.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Edit.ForeColor = System.Drawing.Color.White;
            this.Edit.Location = new System.Drawing.Point(431, 867);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(127, 52);
            this.Edit.TabIndex = 35;
            this.Edit.Text = "编辑";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 940);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.NowUser);
            this.Controls.Add(this.NowAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Consumption);
            this.Controls.Add(this.ConsumptionDGV);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumptionDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Charge;
        private System.Windows.Forms.Label Pay;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Calculate;
        private System.Windows.Forms.DataGridView ConsumptionDGV;
        private System.Windows.Forms.Label Consumption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label NowAccount;
        private System.Windows.Forms.Label NowUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Participant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tips;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
    }
}