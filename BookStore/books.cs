using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookStore
{
    public partial class books : Form
    {
        public books()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\BookStoreDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void populate()
        {
            Con.Open();
            string query = "select * from BookTable1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Filter()
        {
            Con.Open();
            string query = "select * from BookTable1 where BookCategory = '"+comboBox2.SelectedItem.ToString()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(BookTitleTb.Text == ""|| BookAuthorTb.Text == "" || BookPriceTb.Text == ""||BookQuantityTb.Text ==""|| BookCategoryCb.SelectedIndex == -1)
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into BookTable1 values('"+BookTitleTb.Text+"','"+BookAuthorTb.Text+"','"+BookCategoryCb.SelectedItem.ToString()+"','"+BookQuantityTb.Text+"','"+BookPriceTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("保存成功");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
            comboBox2.SelectedIndex = -1;
        }

        private void Reset()
        {
            BookTitleTb.Text = "";
            BookAuthorTb.Text = "";
            BookPriceTb.Text = "";
            BookQuantityTb.Text = "";
            BookCategoryCb.SelectedIndex = -1;
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
            
        }
        int key = 0;
        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BookTitleTb.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            BookAuthorTb.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
            BookCategoryCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
            BookQuantityTb.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            BookPriceTb.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (BookTitleTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
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
                    string query = "delete from BookTable1 where BookId= " + key + " " ;
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (BookTitleTb.Text == ""|| BookAuthorTb.Text == "" || BookPriceTb.Text == ""||BookQuantityTb.Text ==""|| BookCategoryCb.SelectedIndex == -1)
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update BookTable1 set BookTitle='"+BookTitleTb.Text+"', BookAuthor='"+BookAuthorTb.Text+"', BookCategory='"+BookCategoryCb.SelectedItem.ToString()+"', BookQuantity='"+BookQuantityTb.Text+"', BookPrice='"+BookPriceTb.Text+"' where BookId="+key+"";
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
