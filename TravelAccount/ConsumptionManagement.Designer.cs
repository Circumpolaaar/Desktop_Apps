namespace TravelAccount
{
    partial class ConsumptionManagement
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
            this.label5 = new System.Windows.Forms.Label();
            this.GoBack = new System.Windows.Forms.Label();
            this.Consumption = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PayerCb = new System.Windows.Forms.ComboBox();
            this.CLBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TipsTb = new System.Windows.Forms.TextBox();
            this.CategoryCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(559, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 48);
            this.label5.TabIndex = 18;
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
            this.GoBack.TabIndex = 19;
            this.GoBack.Text = "<";
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // Consumption
            // 
            this.Consumption.AutoSize = true;
            this.Consumption.BackColor = System.Drawing.Color.Transparent;
            this.Consumption.Font = new System.Drawing.Font("幼圆", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Consumption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Consumption.Location = new System.Drawing.Point(207, 28);
            this.Consumption.Name = "Consumption";
            this.Consumption.Size = new System.Drawing.Size(173, 37);
            this.Consumption.TabIndex = 20;
            this.Consumption.Text = "账目管理";
            this.Consumption.Click += new System.EventHandler(this.Consumption_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(81, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 22;
            this.label2.Text = "消费类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(81, 265);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 24;
            this.label1.Text = "消费金额";
            // 
            // PriceTb
            // 
            this.PriceTb.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PriceTb.Location = new System.Drawing.Point(325, 263);
            this.PriceTb.Margin = new System.Windows.Forms.Padding(4);
            this.PriceTb.Name = "PriceTb";
            this.PriceTb.Size = new System.Drawing.Size(212, 34);
            this.PriceTb.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(81, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 33);
            this.label3.TabIndex = 26;
            this.label3.Text = "付款人";
            // 
            // PayerCb
            // 
            this.PayerCb.BackColor = System.Drawing.Color.White;
            this.PayerCb.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PayerCb.FormattingEnabled = true;
            this.PayerCb.Items.AddRange(new object[] {
            "Emma",
            "Kiran"});
            this.PayerCb.Location = new System.Drawing.Point(325, 347);
            this.PayerCb.Margin = new System.Windows.Forms.Padding(4);
            this.PayerCb.Name = "PayerCb";
            this.PayerCb.Size = new System.Drawing.Size(212, 32);
            this.PayerCb.TabIndex = 27;
            this.PayerCb.Text = "更多...";
            // 
            // CLBox
            // 
            this.CLBox.BackColor = System.Drawing.Color.White;
            this.CLBox.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CLBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CLBox.FormattingEnabled = true;
            this.CLBox.Items.AddRange(new object[] {
            "Emma",
            "Kiran"});
            this.CLBox.Location = new System.Drawing.Point(325, 576);
            this.CLBox.Name = "CLBox";
            this.CLBox.Size = new System.Drawing.Size(212, 66);
            this.CLBox.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(81, 576);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 33);
            this.label4.TabIndex = 29;
            this.label4.Text = "参与人";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Location = new System.Drawing.Point(325, 416);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(212, 35);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(81, 418);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 33);
            this.label6.TabIndex = 31;
            this.label6.Text = "日期";
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.RoyalBlue;
            this.Edit.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Edit.ForeColor = System.Drawing.Color.White;
            this.Edit.Location = new System.Drawing.Point(342, 710);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(195, 52);
            this.Edit.TabIndex = 34;
            this.Edit.Text = "编辑";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.RoyalBlue;
            this.Add.Font = new System.Drawing.Font("幼圆", 10.5F);
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(87, 710);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(195, 52);
            this.Add.TabIndex = 32;
            this.Add.Text = "添加";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(81, 488);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 33);
            this.label7.TabIndex = 35;
            this.label7.Text = "备注";
            // 
            // TipsTb
            // 
            this.TipsTb.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TipsTb.Location = new System.Drawing.Point(325, 492);
            this.TipsTb.Margin = new System.Windows.Forms.Padding(4);
            this.TipsTb.Name = "TipsTb";
            this.TipsTb.Size = new System.Drawing.Size(212, 34);
            this.TipsTb.TabIndex = 36;
            // 
            // CategoryCb
            // 
            this.CategoryCb.BackColor = System.Drawing.Color.White;
            this.CategoryCb.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CategoryCb.FormattingEnabled = true;
            this.CategoryCb.Items.AddRange(new object[] {
            "餐饮",
            "交通",
            "住宿",
            "购物",
            "其他"});
            this.CategoryCb.Location = new System.Drawing.Point(325, 183);
            this.CategoryCb.Margin = new System.Windows.Forms.Padding(4);
            this.CategoryCb.Name = "CategoryCb";
            this.CategoryCb.Size = new System.Drawing.Size(212, 32);
            this.CategoryCb.TabIndex = 37;
            this.CategoryCb.Text = "更多...";
            // 
            // ConsumptionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 876);
            this.Controls.Add(this.CategoryCb);
            this.Controls.Add(this.TipsTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CLBox);
            this.Controls.Add(this.PayerCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriceTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Consumption);
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsumptionManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsumptionManagement";
            this.Load += new System.EventHandler(this.ConsumptionManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label GoBack;
        private System.Windows.Forms.Label Consumption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PriceTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PayerCb;
        private System.Windows.Forms.CheckedListBox CLBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TipsTb;
        private System.Windows.Forms.ComboBox CategoryCb;
    }
}