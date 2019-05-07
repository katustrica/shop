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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            this.zadacha1TableAdapter.Fill(archive3DataSet.Zadacha1, 2010);
            this.Text.Text = "Запрос на основании объекта TableAdapter";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            this.archive3DataSet.Zadacha1.Clear();
            this.dataGridView1.DataSource = zadacha1BindingSource;
            this.zadacha1TableAdapter.Fill(archive3DataSet.Zadacha1, Convert.ToInt32(form3text.Text));
            this.Text.Text = "Запрос на основании объекта TableAdapter";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.archive3DataSet.Zadacha1.Clear();
            this.dataGridView1.DataSource = zadacha1BindingSource;
            this.sellerTableAdapter.Fill(this.archive3DataSet.seller);
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            //Заполним данными таблицы в датасете
            QueryZapr1();
        }

        public void QueryZapr1()
        {
            archive3DataSet.Zadacha1.Clear();
            //очистим таблицу от предыдущих значений
            foreach (Archive3DataSet.orderrRow oRow in
            archive3DataSet.orderr.Rows)
            {    //пройдём по всем строкам таблицы «Заказы»
                if ((oRow.OrderDate >= Convert.ToDateTime("01.04." + form3text.Text))
             && (oRow.OrderDate <= Convert.ToDateTime("30.04." + form3text.Text)))
                {  //проверка выполнения ограничения на дату

                    foreach (Archive3DataSet.sellerRow sRow in
                    archive3DataSet.seller.Rows)
                    {  //второй цикл по строкам таблицы «Товары»
                        if (oRow.CodeS == sRow.CodeS)
                        {
                            if ((sRow.Birthday >= Convert.ToDateTime("01.01.1970"))
                               && (sRow.Birthday <= Convert.ToDateTime("31.12.1970")))
                            {  //нашли нужный товар
                                Archive3DataSet.Zadacha1Row zRow =
                                archive3DataSet.Zadacha1.NewZadacha1Row();
                                //создали новую строку таблицы «Zadacha1»
                                zRow.CodeS = oRow.CodeS;
                                zRow.Surname = sRow.Surname;
                                zRow.Name = sRow.Name;
                                zRow.birthday = sRow.Birthday;
                                archive3DataSet.Zadacha1.AddZadacha1Row(zRow);
                                //добавили строку в результирующую таблицу
                            }
                        }
                    }
                }
            }
            dataGridView1.Refresh();
            this.Text.Text = "Запрос через двойной цикл";
            //редактирование заголовка формы
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.sellerTableAdapter.Fill(this.archive3DataSet.seller);
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            QueryZapr2();
        }

        private void QueryZapr2()
        {
          
            this.archive3DataSet.Zadacha1.Clear();
            this.dataGridView1.DataSource = zadacha1BindingSource;
            //очистим таблицу от предыдущих значений
            foreach (Archive3DataSet.orderrRow oRow in
            archive3DataSet.orderr.Rows)
            {
                if ((oRow.OrderDate >= Convert.ToDateTime("01.04." + form3text.Text))
                     && (oRow.OrderDate <= Convert.ToDateTime("30.04." + form3text.Text)))
                {
                    Archive3DataSet.sellerRow sRow =
                    archive3DataSet.seller.Rows.Find(oRow.CodeS) as
                    Archive3DataSet.sellerRow;

                    Archive3DataSet.Zadacha1Row zRow =
                                archive3DataSet.Zadacha1.NewZadacha1Row();
                    //создали новую строку таблицы «Zadacha1»
                    zRow.CodeS = oRow.CodeS;
                    zRow.Surname = sRow.Surname;
                    zRow.Name = sRow.Name;
                    zRow.birthday = sRow.Birthday;
                    archive3DataSet.Zadacha1.AddZadacha1Row(zRow);
                }
            }

            dataGridView1.Refresh();
            this.Text.Text = "Запрос через поиск по ключу";
            //редактирование заголовка формы
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.sellerTableAdapter.Fill(this.archive3DataSet.seller);
            this.orderrTableAdapter.Fill(this.archive3DataSet.orderr);
            this.archive3DataSet.Zadacha1.Clear();
            this.dataGridView1.DataSource = zadacha1BindingSource;
            QueryZapr3();
            dataGridView1.Refresh();
        }

        private void QueryZapr3()
        {
           
                archive3DataSet.Zadacha1.Clear();
                foreach (Archive3DataSet.sellerRow sRow in
            archive3DataSet.seller.Rows)
                {  //нашли нужный товар
                    Archive3DataSet.orderrRow oRow =
                    sRow.GetParentRow("ORD_SEL") as
                     Archive3DataSet.orderrRow;
                    Archive3DataSet.Zadacha1Row zRow =
                        archive3DataSet.Zadacha1.NewZadacha1Row();
                        //создали новую строку таблицы «Zadacha1»
                        zRow.CodeS = sRow.CodeS;
                        zRow.Surname = sRow.Surname;
                        zRow.Name = sRow.Name;
                        zRow.birthday = sRow.Birthday;
                        archive3DataSet.Zadacha1.AddZadacha1Row(zRow);
                        //добавили строку в результирующую таблицу
                }
                
            

            dataGridView1.Refresh();
            this.Text.Text = "Запрос через DataRelation";
            //редактирование заголовка формы
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            
            this.archive3DataSet.Zadacha1.Clear();
            
           
            this.dataGridView1.DataSource = zadacha1BindingSource;
            FillGridByReader();
            this.dataGridView1.Refresh();
        }

        private void FillGridByReader()
        {
            SqlConnection con = new SqlConnection(
        Properties.Settings.Default.ShopConnectionString);
            // создаем объект связь с бд, строку соединения берём из
            // свойств проекта, можно задать самим строкой
            con.Open();
            // подключаемся к бд
            String str = "SELECT seller.CodeS, seller.Surname, seller.Name,  seller.birthday FROM seller, orderr WHERE orderr.CodeS = seller.CodeS AND datepart(year, seller.Birthday) = 1970 AND datepart(month, orderr.OrderDate) = 04 AND datepart(year, orderr.OrderDate) = @dateorder ";
            SqlCommand cmd = new SqlCommand(str, con);
            //Console.WriteLine(Convert.ToInt32(Text.Text));
            cmd.Parameters.Add(new SqlParameter("@dateorder", Convert.ToInt32(form3text.Text)));
            SqlDataReader rdr = cmd.ExecuteReader();
            // создали команду и выполнили метод 
            DataTable dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            // при помощи ридера заполнили таблицу и закрыли соединение  
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            // программно создали объект BindingSource и связали его с таблицей, далее грид и навигатор укажем на него 
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.Refresh();
        }
    }
}
