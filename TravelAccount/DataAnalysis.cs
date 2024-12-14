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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravelAccount
{
    public partial class DataAnalysis : Form
    {
        private string tablename;
        public DataAnalysis()
        {

            InitializeComponent();
            tablename = HomePage.TName;


        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\34862\Documents\TravelAccountDataBase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void label5_Click(object sender, EventArgs e)
        {
            HomePage obj = new HomePage();
            obj.Show();
            this.Hide();
        }

        

        private void Filter1()
        {
            Con.Open();
            string query = "select * from "+tablename+" where CCategory = '"+CCat.SelectedItem.ToString()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumptionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Filter2()
        {
            Con.Open();
            string query = "select * from "+tablename+" where CPayer = '"+CPay.SelectedItem.ToString()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumptionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Filter3()
        {
            Con.Open();
            string query = "select * from "+tablename+" where CParticipant like '%" + CPar.SelectedItem.ToString() + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumptionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DataAnalysis_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CCat_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (CCat.SelectedItem != null)
            {
                Filter1();
                //CCat.SelectedIndex = -1;
                CPay.SelectedIndex = -1;
                CPar.SelectedIndex = -1;
            }

        }
        private void CPay_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (CPay.SelectedItem != null)
            {
                Filter2(); 
                CCat.SelectedIndex = -1;
                //CPay.SelectedIndex = -1;
                CPar.SelectedIndex = -1;
            }
        }
        private void CPar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CPar.SelectedItem != null)
            {
                Filter3();
                CCat.SelectedIndex = -1;
                CPay.SelectedIndex = -1;

                //CPar.SelectedIndex = -1;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            populate();
            CCat.SelectedIndex = -1;
            CPay.SelectedIndex = -1;
            CPar.SelectedIndex = -1;
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from "+tablename;
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumptionDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        
    }
}
