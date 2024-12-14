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

namespace BookStore
{
    public partial class Bill : Form
    {
        public Bill()
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

        int key = 0, stock=0;
        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void UpdateStock()
        {
            int newQuantity = stock - Convert.ToInt32(BQuantity.Text);
            try
            {
                Con.Open();
                string query = "update BookTable1 set BookQuantity='"+newQuantity+"' where BookId="+key+"";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("编辑成功");
                Con.Close();
                populate();
                //Chongzhi();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int n = 0, GrdTotal = 0;
        private void Add_Click(object sender, EventArgs e)
        {
            if(BQuantity.Text == "")
            {
                MessageBox.Show("请填写信息");
            }          
            else if(Convert.ToInt32(BQuantity.Text)>stock)
            {
                MessageBox.Show("库存不足");
            }
            else
            {
                int total = Convert.ToInt32(BQuantity.Text)*Convert.ToInt32(BPrice.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(cart);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = BTitle.Text;
                newRow.Cells[3].Value = BQuantity.Text;
                newRow.Cells[2].Value = BPrice.Text;
                newRow.Cells[4].Value = total;
                cart.Rows.Add(newRow);
                n++;
                UpdateStock();
                GrdTotal = GrdTotal + total;
                TotalBill.Text = "总金额："+ GrdTotal + "元";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
            if (cart.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("您还未选择书籍");
            }
            else
            {
                
                try
                {
                    Con.Open();
                    string query = "insert into BillTable1 values('"+UserNameLabel.Text+"',"+GrdTotal+")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("保存成功");
                    Con.Close();
                    //populate();
                    //Chongzhi();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();

                }
            }
        
        }
        int prodid, prodqty, prodprice, tottal, pos = 60;

        private void Bill_Load(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bill_Load_1(object sender, EventArgs e)
        {
            UserNameLabel.Text=Login.UserName;
        }

        private void BookDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BTitle.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            BQuantity.Text = "";
            BPrice.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (BTitle.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
                stock =Convert.ToInt32(BookDGV.SelectedRows[0].Cells[4].Value.ToString());
            }
        }

        private void BQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj= new Login();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }

        string prodname;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("新华书店", new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("编号 产品 价格 数量 总计", new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Red, new Point(26,40));
            foreach(DataGridViewRow row in cart.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column7"].Value);
                prodname = ""+row.Cells["Column8"].Value;
                prodprice= Convert.ToInt32(row.Cells["Column9"].Value);
                prodqty= Convert.ToInt32(row.Cells["Column10"].Value);
                tottal= Convert.ToInt32(row.Cells["Column11"].Value);
                e.Graphics.DrawString(""+prodid, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString(""+prodname, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString(""+prodprice, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString(""+prodqty, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString(""+tottal, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos+=20;

            }
            e.Graphics.DrawString("订单总额：￥"+GrdTotal, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Crimson, new Point(60, pos+50));
            e.Graphics.DrawString("************新华书店************", new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Crimson, new Point(40, pos+85));
            cart.Rows.Clear();
            cart.Refresh();
            pos=100;
            GrdTotal = 0;
        
        }

        

        private void Chongzhi()
        {
            BTitle.Text="";
            BPrice.Text="";
            BQuantity.Text="";

        }

        private void cart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Reset_Click_1(object sender, EventArgs e)
        {
            Chongzhi();
        }
    }
}
