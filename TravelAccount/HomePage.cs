using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAccount
{
    public partial class HomePage : Form
    {
        public static string TName = "";
        public HomePage()
        {
            InitializeComponent();
            TName=ChooseNum();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\TravelAccountDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void populate()
        {
            Con.Open();
            string query = "select * from " + TName; 
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumptionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            DataAnalysis obj = new DataAnalysis();
            obj.Show();
            this.Hide();
        }

        private void ConsumptionDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string DeleteLine = "";
            DeleteLine = ConsumptionDGV.SelectedRows[0].Cells[1].Value.ToString();

            if (DeleteLine == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ConsumptionDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MyAccount obj = new MyAccount();
            obj.Show();
            this.Hide();
        }

        private void Consumption_Click(object sender, EventArgs e)
        {
            ConsumptionManagement obj = new ConsumptionManagement();
            obj.Show();
            this.Hide();
        }

        private void Total_Click(object sender, EventArgs e)
        {

        }

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
        private void HomePage_Load(object sender, EventArgs e)
        {
            NowUser.Text = Login.UserName+"";
            NowAccount.Text = MyAccount.AccountName;

            Con.Open();

            //筛选全部使用
            string query01 = "select sum(CPrice)from " + TName + " where CParticipant = '" + Login.UserName+"'";
            SqlDataAdapter sda01 = new SqlDataAdapter(query01, Con);
            DataTable dt01 = new DataTable();
            sda01.Fill(dt01);
            string TotalUse = dt01.Rows[0][0].ToString();
            if (TotalUse=="") TotalUse= "0";            

            //筛选部分参加
            string query02 = "select sum(CPrice)from " + TName + " where CParticipant like '%" + Login.UserName + "%' and CParticipant != '"+Login.UserName+"'";
            SqlDataAdapter sda02 = new SqlDataAdapter(query02, Con);
            DataTable dt02 = new DataTable();
            sda02.Fill(dt02);
            string PartUse = dt02.Rows[0][0].ToString();
            if (PartUse=="") PartUse= "0";

            //计算实际消费
            Total.Text= ((Convert.ToDouble(PartUse))/2+(Convert.ToDouble(TotalUse))).ToString("0.00");


            //筛选付款
            string query2 = "select sum(CPrice)from " + TName + " where CPayer = '"+Login.UserName+"'";
            SqlDataAdapter sda2 = new SqlDataAdapter(query2, Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            string IPay =dt2.Rows[0][0].ToString();
            if (IPay=="") IPay= "0";
            Pay.Text=Convert.ToDouble(IPay).ToString("0.00");

            //计算 应收 = 付款 - 实消
            Charge.Text =(Convert.ToDouble(Pay.Text)-Convert.ToDouble(Total.Text)).ToString("0.00");
            //MessageBox.Show(Total.Text+"and"+Pay.Text);
            Con.Close();
        }

        private void NowAccount_Click(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void Delete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("请选择账目。");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from "+TName+" where CId= " + key + " ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("删除成功");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        public static int Number =0;

        private void Edit_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("请选择账目。");
            }
            else
            {
                Number=key;
                ConsumptionManagement obj = new ConsumptionManagement();
                obj.Show();
                this.Hide();
                Number=-1;
            }
        }
    }
}
