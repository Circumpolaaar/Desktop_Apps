using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAccount
{
    public partial class ConsumptionManagement : Form
    {
        public static string TableName = "";

        public ConsumptionManagement()
        {
            InitializeComponent();
            TableName=ChooseNum();
            populate();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\TravelAccountDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private string ChooseNum()
        {
            if (MyAccount.AccountNum==1)
                return "ConTable1";
            else if (MyAccount.AccountNum==2)
                return "ConTable2";
            else if (MyAccount.AccountNum==3)
                return "ConTable3";
            else if (MyAccount.AccountNum==4)
                return "ConTable4";
            else
                return "None";
        }
        

        private void Consumption_Click(object sender, EventArgs e)
        {

        }

        private void populate()
        {
            Con.Open();
            string query = "select * from "+TableName+" where CId= " + HomePage.Number + " ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CategoryCb.SelectedItem=reader["CCategory"];
                PriceTb.Text=reader["CPrice"].ToString();
                PayerCb.SelectedItem=reader["CPayer"];

                DateTime dateTimeValue;
                if (DateTime.TryParse(reader["Date"].ToString(), out dateTimeValue))
                {
                    dateTimePicker1.Value = dateTimeValue;
                }
                
                TipsTb.Text=reader["CTips"].ToString();
                reader.Close();

                var ds = new DataSet();
                sda.Fill(ds);
                string[] items = ds.Tables[0].Rows[0]["CParticipant"].ToString().Split(',') ;

                foreach (string item in items)
                {
                    
                    int index = CLBox.Items.IndexOf(item);
                    if (index >= 0)
                    {
                        CLBox.SetItemChecked(index, true);
                    }
                }
                

            }
            
            Con.Close();
        }
        private void Reset()
        {
            CategoryCb.SelectedIndex = -1;
            PriceTb.Text = "";
            TipsTb.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            PayerCb.SelectedIndex = -1;
            CLBox.ClearSelected();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (object item in CLBox.CheckedItems)
            {
                selectedItems.Add(item.ToString());
            }
                string selectedItemsString = string.Join(",", selectedItems);
            
        
              
            if (CategoryCb.SelectedIndex == -1|| PriceTb.Text == "" || PayerCb.SelectedIndex == -1||CLBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into "+TableName+" values('"+CategoryCb.SelectedItem.ToString()+"', " +
                        "'"+PriceTb.Text+"','"+PayerCb.SelectedItem.ToString()+"','"+dateTimePicker1.Value+"', " +
                        "'"+TipsTb.Text+"', '"+selectedItemsString+"')";

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
        int key = 0;
        private void Edit_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (object item in CLBox.CheckedItems)
            {
                selectedItems.Add(item.ToString());
            }
            string selectedItemsString = string.Join(", ", selectedItems);

            if (CategoryCb.SelectedIndex == -1|| PriceTb.Text == "" || PayerCb.SelectedIndex == -1||CLBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("信息缺失。");
            }
            else
            {
                //MessageBox.Show(CLBox.CheckedItems.Count);
                try
                {
                    Con.Open();
                    
                    string query = "update "+TableName+" set CCategory='"+CategoryCb.SelectedItem.ToString()+"', " +
                        "CPrice='"+PriceTb.Text+"', CPayer='"+PayerCb.SelectedItem.ToString()+"', Date='"+dateTimePicker1.Value+"', " +
                        "CTips='"+TipsTb.Text+"', CParticipant='"+selectedItemsString+"' where CId="+key+"";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("编辑成功");
                    Con.Close();
                    populate();
                    Reset();

                    HomePage obj = new HomePage();
                    obj.Show();
                    this.Hide();
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
                    string query = "delete from "+TableName+" where CId= " + key + " ";
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

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            HomePage obj = new HomePage();
            obj.Show();
            this.Hide();
        }

        private void ConsumptionManagement_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
