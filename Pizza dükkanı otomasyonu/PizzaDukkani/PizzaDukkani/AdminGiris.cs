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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-C78OCDS\SQLEXPRESS;Initial Catalog=PizzaDukkani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textKullaniciAdi.Text.ToString();
            string sifre = textSifre.Text.ToString();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from adminler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            Anasayfa anasayfa = new Anasayfa();
            while (oku.Read())
            {
                if ((kullaniciAdi == oku["kullaniciAdi"].ToString()) && (sifre == oku["sifre"].ToString()))
                {
                    anasayfa.Show();
                    this.Hide();
                    break;
                }
                else if((kullaniciAdi != oku["kullaniciAdi"].ToString()) && (sifre == oku["sifre"].ToString()))
                {
                    MessageBox.Show("Kullanıcı adı yanlış girildi.");
                    break;
                }else if((kullaniciAdi == oku["kullaniciAdi"].ToString()) && (sifre != oku["sifre"].ToString()))
                {
                    MessageBox.Show("Şifre yanlış girildi.");
                    break;
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ve şifre yanlış girildi.");
                    break;
                }
            }
            baglanti.Close();
        }

        private void AdminGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
