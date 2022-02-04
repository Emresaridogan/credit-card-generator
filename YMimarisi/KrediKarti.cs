using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMimarisi
{
    public interface KrediKarti
    {
        String kartNumarasınıGetir();
        String kartTuruGetir();
        String kartSahibiniGetir();
        String sonKullanmaTarihiGetir();
        String ccvGetir();
        Object logoGetir();
        double limitiGetir();
        double puanGetir();
        void puanAta(double puan);
        void harcamaYap(double harcamaMiktari);
        void borcOde(double borcMiktari);
        void yazdir();
    }
}
