using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\BookStoreDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void populate()
        {
            Con.Open();
            string query = "select * from UserTable1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == ""|| UserPhoneTb.Text == "" || UserAddressTb.Text == ""||UserPasswordTb.Text =="")
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTable1 values('"+UserNameTb.Text+"','"+UserPhoneTb.Text+"','"+UserAddressTb.Text+"','"+UserPasswordTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("保存成功");
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == ""|| UserPhoneTb.Text == "" || UserAddressTb.Text == ""||UserPasswordTb.Text =="")
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update UserTable1 set UserName='"+UserNameTb.Text+"', UserPhone='"+UserPhoneTb.Text+"', UserAddress='"+UserAddressTb.Text+"', UserPassword='"+UserPasswordTb.Text+"' where UserId="+key+"";
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

        private void Reset()
        {
            UserNameTb.Text = "";
            UserPasswordTb.Text = "";
            UserPhoneTb.Text = "";
            UserAddressTb.Text = "";          
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        int key = 0;

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserNameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UserPhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString(); ;
            UserAddressTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            UserPasswordTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (UserNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
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
                    string query = "delete from UserTable1 where UserId= " + key + " ";
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            books obj = new books();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
