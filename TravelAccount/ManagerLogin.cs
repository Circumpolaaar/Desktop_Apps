using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAccount
{
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UPassTb.Text == "password")
            {
                UserManagement obj = new UserManagement();
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

        private void Customer_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void ManagerLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
