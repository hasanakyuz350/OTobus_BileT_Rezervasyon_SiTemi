using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTobüs_BileT_Rezervasyon_SiTtemi
{
    public partial class Form3 : Form
    {
        static OTobüs_BileT_Rezervasyon_SiTtemiEntities db = new OTobüs_BileT_Rezervasyon_SiTtemiEntities();
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbkasaTable kas = db.dbkasaTable.FirstOrDefault();
            kas.Kasa += Convert.ToDecimal(textBox4.Text);
            db.SaveChanges();
            MessageBox.Show("Yatırma işlemi başarıyla gerçekleşti!");
        }
    }
}
