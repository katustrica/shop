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

namespace Shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.orderrTableAdapter.Update(this.archive3DataSet.orderr);
            this.sellerTableAdapter.Update(this.archive3DataSet.seller);
            this.buyerTableAdapter.Update(this.archive3DataSet.buyer);

            this.sellerTableAdapter.Fill(this.archive3DataSet.seller);
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            this.buyerTableAdapter.Fill(this.archive3DataSet.buyer);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.sellerTableAdapter.Fill(this.archive3DataSet.seller);
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            this.buyerTableAdapter.Fill(this.archive3DataSet.buyer);

        }

        

        private void buyerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingNavigator.BindingSource = buyerBindingSource;
            lblTable.Text = "Покупатели";
            this.buyerDataGridView.DataSource = buyerBindingSource;
        }

        private void orderrDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.buyerDataGridView.DataSource = oRDBUYBindingSource;
            this.sellerDataGridView.DataSource = oRDSELBindingSource;
            lblTable.Text = "Заказы";
        }

        private void sellerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingNavigator.BindingSource = sellerBindingSource;
            lblTable.Text = "Продавцы";
            this.sellerDataGridView.DataSource = sellerBindingSource;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int nRow = orderrDataGridView.CurrentCell.RowIndex;
            int nCol = orderrDataGridView.CurrentCell.ColumnIndex;
            // Если строка – не последняя, увеличиваем номер строки на 1,
            // в противном случае соответству
            if (nRow < orderrDataGridView.RowCount - 1)
                orderrDataGridView.CurrentCell = orderrDataGridView[nCol, ++nRow];
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int nRow = orderrDataGridView.CurrentCell.RowIndex;
            int nCol = orderrDataGridView.CurrentCell.ColumnIndex;
            // Если строка – не последняя, увеличиваем номер строки на 1,
            // в противном случае соответству
            if (nRow > 0)
                orderrDataGridView.CurrentCell = orderrDataGridView[nCol, --nRow];
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            int nCol = orderrDataGridView.CurrentCell.ColumnIndex;
            orderrDataGridView.CurrentCell = orderrDataGridView[nCol, 0];
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int nCol = orderrDataGridView.CurrentCell.ColumnIndex;
            orderrDataGridView.CurrentCell = orderrDataGridView[nCol, orderrDataGridView.RowCount - 1];
        }

        private void orderrDateGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (orderrDataGridView.CurrentCell != null)
            { //если существует выбранная ячейка
                int nRow = orderrDataGridView.CurrentCell.RowIndex;
                //первая строка
                if (nRow == 0)
                {
                    btnPrev.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                }
                //последняя строка
                if (nRow == orderrDataGridView.RowCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnLast.Enabled = true;
                }
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //сохранение данных
            this.orderrTableAdapter.Update(this.archive3DataSet.orderr);
            //обновление данных из источника
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            //обновление состояния навигатора
            this.orderrDateGridView_CurrentCellChanged(orderrDataGridView, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //обновление данных из источника
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            //обновление состояния навигатора
            this.orderrDateGridView_CurrentCellChanged(orderrDataGridView,
            e);
        }

        private void альтернативнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();   
        }

        private void btnSProc_Click(object sender, EventArgs e)
        {
            try
            {
                String CodeB = orderrDataGridView.CurrentCell.Value.ToString();
                SqlConnection con = new SqlConnection();

                con.ConnectionString = Properties.Settings.Default.ShopConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProductCount";

                SqlParameter param = new SqlParameter("@Count", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(new SqlParameter("@CodeBB", CodeB));
                cmd.Parameters.Add(new SqlParameter("@FromDate", dateFrom.Value));

                con.Open();
                cmd.ExecuteNonQuery();
                string kolvo = cmd.Parameters["@Count"].Value.ToString();
                string date = dateFrom.Value.ToString();
                con.Close();
                lblKolvo.Text = " этот продовец совершил с " +date + "   " + kolvo + " сделок";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void вариантToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Form3 f3 = new Form3();
                f3.Show();
            
        }

        private void lblTable_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                orderrBindingSource.AddNew();
            }
            catch { };


        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            orderrDataGridView.Rows.Remove(orderrDataGridView.CurrentRow);
        }
    }
}


