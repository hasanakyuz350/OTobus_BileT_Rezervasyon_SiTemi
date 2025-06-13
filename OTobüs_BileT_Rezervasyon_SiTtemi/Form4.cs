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
    public partial class Form4 : Form , IRezervasyon
    {
        static OTobüs_BileT_Rezervasyon_SiTtemiEntities db = new OTobüs_BileT_Rezervasyon_SiTtemiEntities();
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            rezervasyongorunum rr = new rezervasyongorunum();
            var rezer = db.dberzervasyonTable
                    .Include("dbmusTeriTable")
                    .Include("dbseferTable.dbsehirTable")
                    .ToList();

            var rezerve = rezer.Select(r => new rezervasyongorunum
            {
                ID = r.rezervasyonID,
                MusTeriID = r.dbmusTeriTable.m_ID,
                SeferID = r.dbseferTable.seferID,
                Koltuk_Numarası = r.kolTuknumara.ToString(),
                ÜcreT = r.ucreT,
                Tarih = r.rezervasyonTarihi
            }).ToList();

            dataGridView1.DataSource = rezerve;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            seciliRezervasyonID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

            int m_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MusTeriID"].Value);
            dbmusTeriTable dbmus = db.dbmusTeriTable.FirstOrDefault(x => x.m_ID == m_ID);
            if (dbmus != null)
            {
                textBox1.Text = dbmus.m_ad;
                textBox2.Text = dbmus.m_soyad;
                if (dbmus.cinsiyeT == true)
                {
                    textBox3.Text = "Erkek";
                }
                else
                {
                    textBox3.Text = "Kadın";
                }
                textBox4.Text = Convert.ToString(dbmus.phone);
                textBox5.Text = Convert.ToString(dbmus.mail);
                textBox6.Text = Convert.ToString(dbmus.kimlikno);
            }
            int seferID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SeferID"].Value);


            dbseferTable dbsefer = db.dbseferTable.FirstOrDefault(x => x.seferID == seferID);

            if (dbsefer != null && dbsefer.sehirID.HasValue)
            {
                int sehirID = dbsefer.sehirID.Value;

                dbsehirTable sehir = db.dbsehirTable.FirstOrDefault(x => x.sehirID == sehirID);

                textBox7.Text = sehir.sehir1;
                textBox8.Text = sehir.sehir2;
            }
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["Koltuk_Numarası"].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["Tarih"].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["ÜcreT"].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            rezervasyoncancel();
        }

        public void rezervasyonyap()
        {
            throw new NotImplementedException();
        }

        public int seciliRezervasyonID = 0;
        public void rezervasyoncancel()
        {
            if (seciliRezervasyonID == 0)
            {
                MessageBox.Show("Silinecek rezervasyon seçilmedi.");
                return;
            }

            var silinecekRezervasyon = db.dberzervasyonTable.FirstOrDefault(x => x.rezervasyonID == seciliRezervasyonID);

            if (silinecekRezervasyon != null)
            {
                var onay = MessageBox.Show("Bu rezervasyonu silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    db.dberzervasyonTable.Remove(silinecekRezervasyon);
                    db.SaveChanges();
                    MessageBox.Show("Rezervasyon silindi.");

                    dbkasaTable kas = new dbkasaTable();
                    kas.Kasa += Convert.ToDecimal(textBox11.Text);
                    db.SaveChanges();

                    dataGridView1.DataSource = db.dberzervasyonTable.ToList();
                    TemizleForm();
                    seciliRezervasyonID = 0;
                }
            }
            else
            {
                MessageBox.Show("Rezervasyon bulunamadı.");
            }
            void TemizleForm()
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        textBox.Text = "";
                    }
                }
            }
        }
    }
}

