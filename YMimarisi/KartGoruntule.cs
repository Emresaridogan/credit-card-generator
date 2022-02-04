using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YMimarisi
{
    public partial class KartGoruntule : Form
    {
        public KartGoruntule()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            KrediKarti krediKarti = KrediKartSistemi.krediKarti;
            label4.Text = krediKarti.kartSahibiniGetir();
            label2.Text= krediKarti.kartNumarasınıGetir();
            label6.Text = krediKarti.sonKullanmaTarihiGetir();
            label8.Text = krediKarti.ccvGetir();
            pictureBox2.Image = (Image)krediKarti.logoGetir();
        }
    }
}
