using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMimarisi
{
    public class KrediKartiFactory
    {
        public static KrediKarti krediKartiGetir(string kartSahibi, string bankaAdi, double limit,double puan)
        {
            KrediKarti krediKarti = null;
            if ("MasterCard".Equals(bankaAdi)) // gelen kart türüne göre kart oluşturma
            {
                krediKarti = new MasterCard(kartSahibi, bankaAdi, limit,puan);
            }
            else if ("Visa".Equals(bankaAdi))
            {
                krediKarti = new Visa(kartSahibi, bankaAdi, limit, puan);
            }
            else if ("Amex".Equals(bankaAdi))
            {
                krediKarti = new Amex(kartSahibi, bankaAdi, limit, puan);
            }
            return krediKarti;
        }
    }
}
