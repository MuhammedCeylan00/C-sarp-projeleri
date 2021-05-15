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

namespace pomodro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int CalismaSayac=25;
        private void timer1_Tick(object sender, EventArgs e)
        {
            CalismaSayac--;
            label3.Text = CalismaSayac.ToString();

            if (CalismaSayac == 0)
            {
                timer1.Stop();
                label3.Text = "süreniz bitti ara verebilirsiziniz";
                CalismaSayac = 25;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        int SayacAra = 5;
        private void timer2_Tick(object sender, EventArgs e)
        {
            SayacAra--;
            label4.Text = SayacAra.ToString();
            if (SayacAra == 0)
            {
                timer2.Stop();
                label4.Text = "molanız bitmiştir";
                SayacAra = 5;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        //veri tabanı bağlantısı
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-C78OCDS\\SQLEXPRESS;Initial Catalog=Deneme;Integrated Security=True");
        
        void Listele()
        {
            SqlCommand komut = new SqlCommand(" select * from Calisma ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        void Ekle()
        {
            baglanti.Open();
            SqlCommand KomutEkle = new SqlCommand("insert into Calisma (Tarih,Hedef) values(@p1,@p2)", baglanti);
            KomutEkle.Parameters.AddWithValue("@p1", DateTime.Now.ToString());
            KomutEkle.Parameters.AddWithValue("@p2", textBox1.Text);
            KomutEkle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Ekle();
            }
        }
    }
}
