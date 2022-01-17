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

namespace PizzaDukkani
{
    public partial class Siparisler : Form
    {
        public Siparisler()
        {
            InitializeComponent();
        }

        private void radioButtonMenu1_CheckedChanged(object sender, EventArgs e)
        {
            textMenu.Text = "Menu-1";
            if (textSayi.Text == "")
            {
                textSayi.Text = 0.ToString();
            }
            int sayi = Convert.ToInt32(textSayi.Text.ToString());
            double ucret = sayi * 53.99;
            textUcret.Text = ucret.ToString();
        }

        private void radioButtonMenu2_CheckedChanged(object sender, EventArgs e)
        {
            textMenu.Text = "Menu-2";
            if (textSayi.Text == "")
            {
                textSayi.Text = 0.ToString();
            }
            int sayi = Convert.ToInt32(textSayi.Text.ToString());
            double ucret = sayi * 59.99;
            textUcret.Text = ucret.ToString();
        }

        private void radioButtonMenu3_CheckedChanged(object sender, EventArgs e)
        {
            textMenu.Text = "Menu-3";
            if (textSayi.Text == "")
            {
                textSayi.Text = 0.ToString();
            }
            int sayi = Convert.ToInt32(textSayi.Text.ToString());
            double ucret = sayi * 23.99;
            textUcret.Text = ucret.ToString();
        }

        private void radioButtonMenu4_CheckedChanged(object sender, EventArgs e)
        {
            textMenu.Text = "Menu-4";
            if (textSayi.Text == "")
            {
                textSayi.Text = 0.ToString();
            }
            int sayi = Convert.ToInt32(textSayi.Text.ToString());
            double ucret = sayi * 99.92;
            textUcret.Text = ucret.ToString();
        }

        private void radioButtonMenu5_CheckedChanged(object sender, EventArgs e)
        {
            textMenu.Text = "Menu-5";
            if (textSayi.Text == "")
            {
                textSayi.Text = 0.ToString();
            }
            int sayi = Convert.ToInt32(textSayi.Text.ToString());
            double ucret = sayi * 29.92;
            textUcret.Text = ucret.ToString();
        }

        private void textUcret_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSayi_TextChanged(object sender, EventArgs e)
        {
            int sayi = 0;
            if (textSayi.Text == "")
            {
                textSayi.Text = 0.ToString();
            }
            sayi = Convert.ToInt32(textSayi.Text.ToString());
            double ucret = 0;

            if (radioButtonMenu1.Checked == true)
            {
                ucret = sayi * 53.99;
            }
            if (radioButtonMenu2.Checked == true)
            {
                ucret = sayi * 59.99;
            }
            if (radioButtonMenu3.Checked == true)
            {
                ucret = sayi * 23.99;
            }
            if (radioButtonMenu4.Checked == true)
            {
                ucret = sayi * 99.92;
            }
            if (radioButtonMenu5.Checked == true)
            {
                ucret = sayi * 29.92;
            }
            textUcret.Text = ucret.ToString();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-C78OCDS\SQLEXPRESS;Initial Catalog=PizzaDukkani;Integrated Security=True");

        private void VerileriGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from siparisler ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kurye"].ToString();
                ekle.SubItems.Add(oku["menu"].ToString());
                ekle.SubItems.Add(oku["sayi"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["ucret"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string menu = "";
            if (radioButtonMenu1.Checked)
            {
                menu = "MENÜ-1";
            }
            if (radioButtonMenu2.Checked)
            {
                menu = "MENÜ-2";
            }
            if (radioButtonMenu3.Checked)
            {
                menu = "MENÜ-3";
            }
            if (radioButtonMenu4.Checked)
            {
                menu = "MENÜ-4";
            }
            if (radioButtonMenu5.Checked)
            {
                menu = "MENÜ-5";
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into siparisler (kurye,menu,sayi,ucret,telefon,tarih,adres) values('" + comboBoxKurye.Text + "','" + menu + "','" + textSayi.Text + "','" + textUcret.Text + "','" + textTelefon.Text + "','" + DateTime.Now.ToString() + "','" + textAdres.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listView1.Items.Clear();
            VerileriGoster();
        }

        private void Siparisler_Load(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete  from siparisler where kurye=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBoxKuryeDondu.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listView1.Items.Clear();
            VerileriGoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
