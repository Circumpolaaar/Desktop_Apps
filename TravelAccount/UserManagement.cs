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

namespace TravelAccount
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\TravelAccountDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        int key = 0;
        private void populate()
        {
            Con.Open();
            string query = "select * from UserTable0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PartnerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            
            Name1.Text = "";
            Password1.Text = "";
            
        }
        private void BookTitleTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Name1.Text == ""|| Password1.Text == "" )
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTable0 values('"+Name1.Text+"','"+Password1.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (Name1.Text == ""|| Password1.Text == "")
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update UserTable0 set UserName='"+Name1.Text+"', UserPassword='"+Password1.Text+"' where UserId="+key+"";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("编辑成功");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UserTable0 where UserId= " + key + " ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("删除成功");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PartnerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Name1.Text = PartnerDGV.SelectedRows[0].Cells[1].Value.ToString();
            Password1.Text = PartnerDGV.SelectedRows[0].Cells[2].Value.ToString(); ;
            if (Name1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PartnerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            ManagerLogin obj = new ManagerLogin();
            obj.Show();
            this.Hide();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
