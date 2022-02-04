using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YMimarisi
{
    public class MasterCard : KrediKarti
    {
        private string kartNumarasi;
        private string kartSahibi;
        private string kartTuru;
        private string sonKullanmaTarihi;
        private string ccv;
        private object logo = Properties.Resources.mastercard;
        private double limit;
        private double puan;
        public MasterCard(string kartSahibi, string kartTuru, double limit, double puan)
        {
            this.kartNumarasi = kartNumarasiOlustur();
            this.kartSahibi = kartSahibi;
            this.kartTuru = kartTuru;
            this.sonKullanmaTarihi = sonKullanmaTarihiOlustur();
            this.ccv = ccvOlustur();
            this.limit = limit;
            this.puan = puan;
        }
        public MasterCard(){}
        public double puanGetir()
        {
            return puan;
        }
        public void puanAta(double puan)
        {
            this.puan = puan;
        }
        public string kartNumarasınıGetir()
        {
            String k1, k2, k3, k4;
            String kart = kartNumarasi;
            k1 = kart.Substring(0, 4);
            k2 = kart.Substring(4, 4);
            k3 = kart.Substring(8, 4);
            k4 = kart.Substring(12, 4);
            // **** **** **** **** şeklinde görünmesi için
            String kartNo = k1 + " " + k2 + " " + k3 + " " + k4;
            return kartNo;
        }
        public string kartTuruGetir()
        {
            return kartTuru;
        }
        public void kartTuruAta(string kartTuru)
        {
            this.kartTuru = kartTuru;
        }
        public string kartSahibiniGetir()
        {
            return kartSahibi;
        }
        public void kartSahibiniAta(string kartSahibi)
        {
            this.kartSahibi = kartSahibi;
        }
        public string sonKullanmaTarihiOlustur()
        {
            String ay = "0";
            Random rnd = new Random();
            int sayi = rnd.Next(4, 9); // kartın kullanım süresi 4 ile 9 yıl arası
            String dateYear = DateTime.Now.Year.ToString(); // şuanki yılı alma
            int yil = int.Parse(dateYear.Substring(2, 2)); // yılın son 2 rakamını alma
            yil = yil + sayi;  // ccv yılı oluşturmak için
            int dateMonth = rnd.Next(1, 12); // ccv ay oluşturma
            if (dateMonth.ToString().Length == 1)
            {
                ay += dateMonth.ToString(); // tek rakamlı ise başında 0 olacak
            }
            else
            {
                ay = dateMonth.ToString();
            }
            return ay + "/" + yil;
        }
        public string sonKullanmaTarihiGetir()
        {
            return sonKullanmaTarihi;
        }
        public string ccvOlustur()
        {
            Random rnd = new Random();
            return rnd.Next(100, 999).ToString();
        }
        public string ccvGetir()
        {
            return ccv;
        }
        public object logoGetir()
        {
            return logo;
        }
        public double limitiGetir()
        {
            return limit;
        }
        public void limitAta(double limit)
        {
            this.limit = limit;
        }
        public void harcamaYap(double harcamaMiktari)
        {
            limit -= harcamaMiktari;
        }
        public void borcOde(double borcMiktari)
        {
            limit+=borcMiktari;
        }
        public string kartNumarasiOlustur()
        {
            bool don = true;
            String kartNo = "";
            List<int> sayilar = new List<int>();
            Random rand = new Random();
            while (don) // luhn algoritması doğru olduğu sürece dönecek
            {
                sayilar.Clear();
                int topla = 0;
                int gecici = 0;
                sayilar.Add(5); // masterCard kart numarası 5 ile başlar.
                sayilar.Add(rand.Next(1, 6)); // ikinci numarası 1-5 e kadar değerler alır
                for (int i = 1; i <= 14; i++)
                {
                    sayilar.Add(rand.Next(0, 9)); // geriye kalanlar random atılır
                }
                bool sec = false; // hangi sayıları 2 ile çarpacağımızı belirlemek için
                for (int j = sayilar.Count - 1; j >= 0; j--)
                {
                    gecici = sayilar[j];
                    if (sec) // true ise 
                    {
                        gecici *= 2;
                        if (gecici > 9) // iki basamaklı ise 
                        {
                            gecici = (gecici % 10) + 1; // rakamları toplamını alma
                        }
                    }
                    topla += gecici;
                    sec = !sec;
                }
                if (topla % 10 == 0)
                {
                    don = !don; // algoritmaya uygunsa while döngüsünü bitirecek
                }
                else
                {
                    don = true;
                }
            }
            foreach (var item in sayilar)
            {
                kartNo += item.ToString();
            }
            return kartNo;
        }
        public void yazdir()
        {
            String bilgiler = "Kart Numarası : " + kartNumarasi + "\n" +
                              "Kart Sahibi : " + kartSahibi + "\n" +
                              "Kart Türü : " + kartTuru + "\n" +
                              "Limit : " + limit + "\n" +
                              "Son Kullanma Tarihi : " + sonKullanmaTarihi + "\n" +
                              "CCV : " + ccv + "\n" +
                              "Puan : " + puan;
            MessageBox.Show(bilgiler);
        }
    }
}
