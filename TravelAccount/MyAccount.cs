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
    public partial class MyAccount : Form
    {
        public MyAccount()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AccountMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        

        public static int AccountNum=0;
        public static string AccountName = "";
        private void MyAccount_Load(object sender, EventArgs e)
        {

        }

        private void L1_Click(object sender, EventArgs e)
        {
            AccountNum = 1;
            AccountName = "序章";
            HomePage obj = new HomePage();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AccountNum = 2;
            AccountName = "发展";
            HomePage obj = new HomePage();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AccountNum = 3;
            AccountName = "高潮";
            HomePage obj = new HomePage();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            AccountNum = 4;
            AccountName = "尾声";
            HomePage obj = new HomePage();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (AccountNum == 0)
            {
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
            else
            {
                HomePage obj = new HomePage();
                obj.Show();
                this.Hide();
            }
        }
    }
}
