using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pomodro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string GKAdi, GSifre;

            GKAdi = Convert.ToString(textBox1.Text);
            GSifre = Convert.ToString(textBox2.Text);

            string KAdi = "Muhammed123", Sifre = "123321";

            Form2 YeniForm = new Form2();

            if(KAdi==GKAdi && GSifre == Sifre)
            {
                YeniForm.Show();
                this.Hide();
            }
            if(GKAdi==KAdi && GSifre != Sifre)
            {
                label3.Text = "Şifrenizi doğru giriniz!";
            }
            if (GKAdi != KAdi && GSifre == Sifre)
            {
                label3.Text = "Kullanıcı adınızı doğru giriniz!";
            }
            if (GKAdi != KAdi && GSifre != Sifre)
            {
                label3.Text = "Şifrenizi ve kullanıcı adınızı doğru giriniz!";
            }
        }
    }
}
