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
    public partial class Menü : Form
    {
        KrediKarti krediKarti;
        FacadePattern facade;
        public Menü()
        {
            InitializeComponent();
        }
        private void Menü_Load(object sender, EventArgs e)
        {
            krediKarti = KrediKartSistemi.krediKarti; // oluşturulan karta ulaşırız
        }
        private void button1_Click(object sender, EventArgs e) // harcama yapma işlemi
        {
            krediKarti.harcamaYap(double.Parse(textBox1.Text.ToString()));
        }
        private void button3_Click(object sender, EventArgs e) // facade pattern kullanarak puan ile ödeme işlemi
        {
            facade = new FacadePattern(krediKarti);
            facade.puanIleOde(krediKarti,double.Parse(textBox1.Text.ToString()));
        }
        private void button2_Click(object sender, EventArgs e) // borc odeme işlemi
        {
            krediKarti.borcOde(double.Parse(textBox1.Text.ToString()));
        }
        private void button4_Click(object sender, EventArgs e) // facade pattern ile krediKarti bilgilerini yazdırır
        {
            facade = new FacadePattern(krediKarti);
            facade.yazdir();
        }
    }
}
