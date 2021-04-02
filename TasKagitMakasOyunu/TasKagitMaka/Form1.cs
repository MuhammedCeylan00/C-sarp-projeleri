using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasKagitMaka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int PuanBilgisayar = 0, PuanOyuncu = 0;
        int sayac = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string[] dizi = { "tas", "kagit", "makas" };
            Random random = new Random();
            int sayi = random.Next(0, 3);
            string Bilgisayar = dizi[sayi];
            label2.Text = Bilgisayar;
            if((PuanOyuncu==3) || (PuanBilgisayar == 3))
            {
                sayac++;
                
                if (PuanOyuncu > PuanBilgisayar)
                {
                    label5.Text = sayac + ". turda kazanan oyuncu";
                }
                else if (PuanBilgisayar > PuanOyuncu)
                {
                    label5.Text = sayac + ". turda kazanan bilgisayar";
                }
                else if (PuanBilgisayar == PuanOyuncu)
                {
                    label5.Text = sayac + ". turda berabere";
                }
                PuanBilgisayar = 0;
                PuanOyuncu = 0; 
            }

            if ((radioButton1.Checked == true) && (Bilgisayar == "tas"))
            {
                PuanBilgisayar++;
                PuanOyuncu++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;

            }
            else if ((radioButton1.Checked == true) && (Bilgisayar == "kagit"))
            {
                PuanBilgisayar++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton1.Checked == true) && (Bilgisayar == "makas"))
            {
                PuanOyuncu++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton2.Checked == true) && (Bilgisayar == "tas"))
            {
                PuanOyuncu++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton2.Checked == true) && (Bilgisayar == "kagit"))
            {
                PuanBilgisayar++;
                PuanOyuncu++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton1.Checked == true) && (Bilgisayar == "makas"))
            {
                PuanBilgisayar++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton3.Checked == true) && (Bilgisayar == "tas"))
            {
                PuanBilgisayar++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton3.Checked == true) && (Bilgisayar == "kagit"))
            {
                PuanOyuncu++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }
            else if ((radioButton3.Checked == true) && (Bilgisayar == "makas"))
            {
                PuanBilgisayar++;
                PuanOyuncu++;
                label4.Text = "bilgisayar:" + PuanBilgisayar + "-oyuncu:" + PuanOyuncu;
            }

        }
    }
}
