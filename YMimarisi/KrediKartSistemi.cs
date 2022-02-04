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
    public partial class KrediKartSistemi : Form
    {
        public static KrediKarti krediKarti;
        public KrediKartSistemi()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KartGoruntule frm2 = new KartGoruntule();
            Menü menu = new Menü();
            String kartSahibi = " ", kartTuru = " ";
            double limit = 0, puan = 0;
            if (!textBox1.Text.Equals("")) // TextBox boş değilse
            {
                kartSahibi = textBox1.Text;
            }
            if (!comboBox1.Text.Equals("")) // ComboBox boş değilse
            {
                kartTuru = comboBox1.Text;
            }
            if (!comboBox2.Text.Equals("")) // ComboBox boş değilse
            {
                limit = double.Parse(comboBox2.SelectedItem.ToString());
            }
            if (!textBox2.Text.Equals("")) // TextBox boş değilse
            {
                puan = double.Parse(textBox2.Text.ToString());
            }
            // FactoryPattern aracılığıyla kredi kartı oluşturma
            krediKarti = KrediKartiFactory.krediKartiGetir(kartSahibi, kartTuru, limit,puan); 
            frm2.Show(); // kart tasarımının açılması
            menu.Show(); // kart ile yapılacak işlemin seçilmesi için açılan form
        }
    }
}
