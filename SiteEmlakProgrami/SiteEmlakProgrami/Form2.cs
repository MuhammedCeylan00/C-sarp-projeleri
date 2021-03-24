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

namespace SiteEmlakProgrami
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Siteler;Integrated Security=True");
        private void VerileriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from SiteBilgi ", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Zambak  sitesi")
            {
                button1.BackColor = Color.Yellow;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Papatya sitesi")
            {
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Yellow;
                button4.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Gül sitesi")
            {
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Yellow;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Menekşe sitesi")
            {
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Yellow;
            }
        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into SiteBilgi(id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) " +
                 "values('" + maskedTextBox7.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + 
                "','" + maskedTextBox1.Text.ToString() + "','" + maskedTextBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" 
                + maskedTextBox3.Text.ToString() + "','" + maskedTextBox4.Text.ToString() + "','" + maskedTextBox5.Text.ToString() + "','" +
                maskedTextBox6.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }
        int id = 0;
        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from SiteBilgi where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            maskedTextBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text= listView1.SelectedItems[0].SubItems[2].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            maskedTextBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            maskedTextBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
            maskedTextBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            maskedTextBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            maskedTextBox6.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;
            
        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update SiteBilgi det id='" + maskedTextBox7.Text.ToString()
                + "',site='" + comboBox1.Text.ToString() + "',oda'" + comboBox3.Text.ToString() + "',metre='" + maskedTextBox1.Text.ToString()
                + "',fiyat='" + maskedTextBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',no='" + maskedTextBox3.Text.ToString() + "',adsoyad'" + maskedTextBox4.Text.ToString()
                + "',telefon='" + maskedTextBox5.Text.ToString() + "',notlar='" + maskedTextBox6.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "'where id=" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }
    }
}
