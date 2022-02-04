using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMimarisi
{
    public class FacadePattern
    {
        private KrediKarti masterCard;
        private KrediKarti visa;
        private KrediKarti amex;
        private KrediKarti krediKart;
        public FacadePattern()
        {
            masterCard = new MasterCard();
            visa = new Visa();
            amex = new Amex();
        }
        public FacadePattern(KrediKarti krediKarti)
        {
            krediKart = krediKarti;
        }
        // Kartın detaylarını saklayarak tek bir ön yüz üzerinden iletilmesini sağlar
        public void mastercardYazdir()
        {
            masterCard.yazdir();
        }
        public void visaYazdir()
        {
            visa.yazdir();
        }
        public void amexYazdir()
        {
            amex.yazdir();
        }
        public void yazdir()
        {
            krediKart.yazdir();
        }
        public void puanIleOde(KrediKarti krediKarti,double miktar) // class yapısını bozmadan puan ile ödeme fonksiyonu
        {
            double puan = krediKarti.puanGetir();
            puan -= miktar;
            krediKarti.puanAta(puan);
        }
    }
}
