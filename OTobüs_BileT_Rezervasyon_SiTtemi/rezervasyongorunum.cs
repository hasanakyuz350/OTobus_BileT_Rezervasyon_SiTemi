using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTobüs_BileT_Rezervasyon_SiTtemi
{
    public class rezervasyongorunum
    {
        public int ID { get; set; }
        public int MusTeriID { get; set; }
        public int SeferID { get; set; }
        public string Koltuk_Numarası { get; set; }
        public decimal? ÜcreT { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
