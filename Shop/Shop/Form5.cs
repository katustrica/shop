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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "archive3DataSet.buyer1". При необходимости она может быть перемещена или удалена.
            this.buyer1TableAdapter.Fill(this.archive3DataSet.buyer1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.buyer1TableAdapter.Fill(this.archive3DataSet.buyer1);
            dataGridView1.AutoGenerateColumns = true;
            this.buyer1TableAdapter.Fill(archive3DataSet.buyer1);
            this.Text = "Запрос на основании объекта TableAdapter";
        }
        private void Query()

        {

            archive3DataSet.buyer1.Clear();
            int sum = 0, kod = -1;
            Archive3DataSet.buyer1Row zRow = null;
            foreach (Archive3DataSet.orderrRow oRow in archive3DataSet.orderr.Rows)
            {
                if (zRow == null)
                {
                    zRow = archive3DataSet.buyer1.Newbuyer1Row();
                    kod = oRow.CodeB;
                }
                else
                if (kod == oRow.CodeB)
                    sum += Convert.ToInt32(oRow.Summ);
                else
                {
                    zRow.summa_buyer = sum;
                    Archive3DataSet.buyerRow rRow = archive3DataSet.buyer.FindByCodeB(kod) as Archive3DataSet.buyerRow;
                    zRow.Surname = rRow.Surname;                      
                    archive3DataSet.buyer1.Rows.Add(zRow);
                    kod = oRow.CodeB;//подготовливаем новую строку
                    sum = 0;
                    zRow = archive3DataSet.buyer1.Newbuyer1Row();
                }
            }
            if (zRow != null)//проверяем последний товар
            {
                zRow.summa_buyer = sum;
                Archive3DataSet.buyerRow rRow = archive3DataSet.buyer.FindByCodeB(kod) as Archive3DataSet.buyerRow;
                zRow.Surname = rRow.Surname;
                archive3DataSet.buyer1.Rows.Add(zRow);
            }
            dataGridView1.Refresh();
        }

        private void btn2_Click(object sender, EventArgs e)
        {            
                Query();
                this.Text = "Запрос через поиск по ключу";
                this.buyer1TableAdapter.Fill(this.archive3DataSet.buyer1);            
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {          
                this.archive3DataSet.buyer1.Clear();
                this.dataGridView1.Refresh();
                this.dataGridView1.DataSource = buyer1BindingSource;
        }
    }
}
