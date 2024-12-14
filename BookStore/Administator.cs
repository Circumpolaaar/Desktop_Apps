using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Administator : Form
    {
        public Administator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UPassTb.Text == "password")
            {
                books obj = new books();
                obj.Show();
                this.Hide();
            }
            else if (UPassTb.Text=="")
            {
                MessageBox.Show("请输入密码。");
            }
            else
            {
                MessageBox.Show("密码错误。");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
