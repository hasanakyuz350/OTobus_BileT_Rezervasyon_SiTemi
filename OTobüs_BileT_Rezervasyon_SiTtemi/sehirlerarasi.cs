using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTobüs_BileT_Rezervasyon_SiTtemi
{
    internal class sehirlerarasi : dbseferTable
    {
        public decimal FiyatHesapla(int mesafe)
        {
            decimal temelFiyat = 0;

            if (mesafe > 300)
                temelFiyat = mesafe * 3;
            else
                temelFiyat = mesafe * 1;

            return temelFiyat;
        }


        public override string SeferBilgisi()
        {
            return base.SeferBilgisi() + ($" | Mesafe: {dbsehirTable.mesafe_KM}km");
        }
    }
}
