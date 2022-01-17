using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaDukkani
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        
        Masalar masalar = new Masalar();
        private void button2_Click(object sender, EventArgs e)
        {
            masalar.Show();
        }
        Siparisler Siparisler = new Siparisler();
        private void button1_Click(object sender, EventArgs e)
        {
            Siparisler.Show();
        }
    }
}
