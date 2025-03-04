using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TravelAccount
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\TravelAccountDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTable0 where UserName='"+UNameTb.Text+"' and UserPassword='"+UPassTb.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                UserName = UNameTb.Text;
                Con.Close();
                MyAccount obj1 = new MyAccount();
                obj1.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("用户名或密码错误。");
                Con.Close();

            }
            
            
        }

        private void Manager_Click(object sender, EventArgs e)
        {
            ManagerLogin obj = new ManagerLogin();
            obj.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
