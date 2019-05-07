using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "archive3DataSet.seller". При необходимости она может быть перемещена или удалена.
            this.sellerTableAdapter.Fill(this.archive3DataSet.seller);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "archive3DataSet.orderr". При необходимости она может быть перемещена или удалена.
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "archive3DataSet.buyer". При необходимости она может быть перемещена или удалена.
            this.buyerTableAdapter.Fill(this.archive3DataSet.buyer);
            dataGridView1.AutoGenerateColumns = true;
        }

        private void btnBuyer_Click(object sender, EventArgs e)
        {
            if (lblTableName.Text != "Покупатели")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = buyerBindingSource;
                bindingNavigator1.BindingSource = buyerBindingSource;
                lblTableName.Text = "Покупатели";
            }
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            if (lblTableName.Text != "Продавцы")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = sellerBindingSource;
                bindingNavigator1.BindingSource = sellerBindingSource;
                lblTableName.Text = "Продавцы";
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lblTableName.Text != "Заказы")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = orderrBindingSource;
                bindingNavigator1.BindingSource = orderrBindingSource;
                lblTableName.Text = "Заказы";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tableAdapterManager1.UpdateAll(this.archive3DataSet);
            MessageBox.Show("Изменения сохранены");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
