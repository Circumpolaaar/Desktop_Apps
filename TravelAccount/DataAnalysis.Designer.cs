namespace TravelAccount
{
    partial class DataAnalysis
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ConsumptionDGV = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPar = new System.Windows.Forms.ComboBox();
            this.CCat = new System.Windows.Forms.ComboBox();
            this.CPay = new System.Windows.Forms.ComboBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumptionDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 48);
            this.label1.TabIndex = 13;
            this.label1.Text = "分类查询";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(1300, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 48);
            this.label5.TabIndex = 23;
            this.label5.Text = "x";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ConsumptionDGV
            // 
            this.ConsumptionDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConsumptionDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ConsumptionDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ConsumptionDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.ConsumptionDGV.Location = new System.Drawing.Point(46, 281);
            this.ConsumptionDGV.Margin = new System.Windows.Forms.Padding(4);
            this.ConsumptionDGV.Name = "ConsumptionDGV";
            this.ConsumptionDGV.ReadOnly = true;
            this.ConsumptionDGV.RowHeadersVisible = false;
            this.ConsumptionDGV.RowHeadersWidth = 82;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.ConsumptionDGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ConsumptionDGV.RowTemplate.Height = 37;
            this.ConsumptionDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConsumptionDGV.Size = new System.Drawing.Size(1264, 628);
            this.ConsumptionDGV.TabIndex = 24;
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
            // CPar
            // 
            this.CPar.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CPar.FormattingEnabled = true;
            this.CPar.Items.AddRange(new object[] {
            "Emma",
            "Kiran"});
            this.CPar.Location = new System.Drawing.Point(860, 188);
            this.CPar.Margin = new System.Windows.Forms.Padding(2);
            this.CPar.Name = "CPar";
            this.CPar.Size = new System.Drawing.Size(206, 32);
            this.CPar.TabIndex = 25;
            this.CPar.Text = "选定参与人";
            this.CPar.SelectedIndexChanged += new System.EventHandler(this.CPar_SelectedIndexChanged);
            // 
            // CCat
            // 
            this.CCat.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CCat.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CCat.FormattingEnabled = true;
            this.CCat.Items.AddRange(new object[] {
            "餐饮",
            "交通",
            "住宿",
            "购物",
            "其他"});
            this.CCat.Location = new System.Drawing.Point(132, 188);
            this.CCat.Margin = new System.Windows.Forms.Padding(2);
            this.CCat.Name = "CCat";
            this.CCat.Size = new System.Drawing.Size(206, 32);
            this.CCat.TabIndex = 26;
            this.CCat.Text = "选定类型";
            this.CCat.SelectedIndexChanged += new System.EventHandler(this.CCat_SelectedIndexChanged);
            // 
            // CPay
            // 
            this.CPay.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CPay.FormattingEnabled = true;
            this.CPay.Items.AddRange(new object[] {
            "Emma",
            "Kiran"});
            this.CPay.Location = new System.Drawing.Point(502, 188);
            this.CPay.Margin = new System.Windows.Forms.Padding(2);
            this.CPay.Name = "CPay";
            this.CPay.Size = new System.Drawing.Size(206, 32);
            this.CPay.TabIndex = 27;
            this.CPay.Text = "选定付款人";
            this.CPay.SelectedIndexChanged += new System.EventHandler(this.CPay_SelectedIndexChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpdateButton.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(1138, 184);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(103, 44);
            this.UpdateButton.TabIndex = 28;
            this.UpdateButton.Text = "重置";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(130, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 33);
            this.label2.TabIndex = 29;
            this.label2.Text = "选择消费类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(515, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 33);
            this.label3.TabIndex = 30;
            this.label3.Text = "选择付款人";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(870, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 33);
            this.label4.TabIndex = 31;
            this.label4.Text = "选择参与人";
            // 
            // DataAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 940);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.CPay);
            this.Controls.Add(this.CCat);
            this.Controls.Add(this.CPar);
            this.Controls.Add(this.ConsumptionDGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataAnalysis";
            this.Load += new System.EventHandler(this.DataAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConsumptionDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView ConsumptionDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Participant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tips;
        private System.Windows.Forms.ComboBox CPar;
        private System.Windows.Forms.ComboBox CCat;
        private System.Windows.Forms.ComboBox CPay;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}