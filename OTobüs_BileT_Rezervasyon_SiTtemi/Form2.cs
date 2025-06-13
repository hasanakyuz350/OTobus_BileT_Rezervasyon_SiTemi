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
    public partial class Form2 : Form, IRezervasyon
    {
        static OTobüs_BileT_Rezervasyon_SiTtemiEntities db = new OTobüs_BileT_Rezervasyon_SiTtemiEntities();
        private int currentSeferID = 0;
        private int currentBusID = 0;
        private List<int> doluKoltuklar = new List<int>();

        public Form2()
        {
            InitializeComponent();
        }

        private DateTime tarih;
        private string nereden;
        private string nereye;

        public Form2(string nereden, string nereye, DateTime tarih)
        {
            InitializeComponent();
            this.nereden = nereden;
            this.nereye = nereye;
            this.tarih = tarih;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var sehir = db.dbsehirTable.FirstOrDefault(x => x.sehir1 == nereden && x.sehir2 == nereye);
            if (sehir != null)
            {
                int sehirId = sehir.sehirID;
                var s = db.dbseferTable.FirstOrDefault(x => x.sehirID == sehirId &&
                    x.daTe.HasValue &&
                    x.daTe.Value.Year == tarih.Year &&
                    x.daTe.Value.Month == tarih.Month &&
                    x.daTe.Value.Day == tarih.Day);
                sehirlerarasi seh = new sehirlerarasi();
                dbsehirTable dbseh = new dbsehirTable();
                if (s != null)
                {
                    currentSeferID = s.seferID;
                    currentBusID = s.busID.HasValue ? s.busID.Value : 0;

                    if (s.fiyaT.HasValue)
                    {
                        label7.Text = s.fiyaT.Value.ToString();
                    }
                    else
                        label7.Text = "Fiyat bilgisi yok";
                        
                    if (s.daTe.HasValue)
                        label8.Text = s.daTe.Value.Date.ToShortDateString();
                    else
                        label8.Text = "Tarih bilgisi yok";

                    DoluKoltuklariYukle();
                    RadioButtonlariAyarla();
                }
                else
                {
                    MessageBox.Show("Bu şehirler ve tarih için sefer bulunamadı.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Şehir eşleşmesi bulunamadı.");
            }
        }

        private void DoluKoltuklariYukle()
        {
            var doluKoltukListesi = db.dberzervasyonTable
                .Where(x => x.seferID == currentSeferID)
                .Select(x => x.kolTuknumara)
                .ToList();

            doluKoltuklar.Clear();
            foreach (var koltuk in doluKoltukListesi)
            {
                if (koltuk.HasValue)
                {
                    doluKoltuklar.Add(koltuk.Value);
                }
            }
        }

        private void RadioButtonlariAyarla()
        {
            var otobus = db.dboTobusTable.FirstOrDefault(x => x.busID == currentBusID);
            if (otobus != null && otobus.kolTuksayisi.HasValue)
            {
                int koltukSayisi = otobus.kolTuksayisi.Value;

                foreach (Control control in this.Controls)
                {
                    if (control is RadioButton radioButton)
                    {
                        if (radioButton.Tag != null && int.TryParse(radioButton.Tag.ToString(), out int koltukNo))
                        {
                            if (koltukNo <= koltukSayisi)
                            {
                                radioButton.Visible = true;

                                if (doluKoltuklar.Contains(koltukNo))
                                {
                                    radioButton.Enabled = false;
                                    radioButton.Text = $"{koltukNo}";
                                    radioButton.BackColor = Color.Red;
                                }
                                else
                                {
                                    radioButton.Enabled = true;
                                    radioButton.Text = $"{koltukNo}";
                                    radioButton.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                radioButton.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private int SeciliKoltukNumarasi()
        {
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    if (radioButton.Tag != null && int.TryParse(radioButton.Tag.ToString(), out int koltukNo))
                    {
                        return koltukNo;
                    }
                }
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rezervasyonyap();
        }

        private void TemizleForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = -1;

            foreach (Control control in this.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        public void rezervasyonyap()
        {
            try
            {
                int seciliKoltuk = SeciliKoltukNumarasi();
                if (seciliKoltuk == 0)
                {
                    MessageBox.Show("Lütfen bir koltuk seçiniz!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                    return;
                }

                dbmusTeriTable dbmus = new dbmusTeriTable();
                dbmus.m_ad = textBox1.Text;
                dbmus.m_soyad = textBox2.Text;
                dbmus.cinsiyeT = comboBox1.Text == "Erkek" ? true : false;
                if (int.TryParse(textBox4.Text, out int phone))
                    dbmus.phone = (byte?)phone;
                else
                {
                    MessageBox.Show("Geçersiz telefon numarası!");
                    return;
                }

                if (int.TryParse(textBox6.Text, out int kimlik))
                    dbmus.kimlikno = (byte?)kimlik;
                else
                {
                    MessageBox.Show("Geçersiz kimlik numarası!");
                    return;
                }

                dbmus.mail = textBox5.Text;

                db.dbmusTeriTable.Add(dbmus);
                db.SaveChanges();

                int musteriID = dbmus.m_ID;

                dberzervasyonTable rezervasyon = new dberzervasyonTable();
                rezervasyon.seferID = currentSeferID;
                rezervasyon.m_ID = musteriID;
                rezervasyon.kolTuknumara = (byte)seciliKoltuk;

                var sefer = db.dbseferTable.FirstOrDefault(x => x.seferID == currentSeferID);
                if (sefer != null && sefer.fiyaT.HasValue)
                {
                    rezervasyon.ucreT = (decimal)sefer.fiyaT.Value;
                }

                rezervasyon.rezervasyonTarihi = DateTime.Now;

                db.dberzervasyonTable.Add(rezervasyon);
                db.SaveChanges();

                MessageBox.Show($"Rezervasyon başarıyla tamamlandı!\nKoltuk No: {seciliKoltuk}\nMüşteri: {textBox1.Text} {textBox2.Text}");

                dbkasaTable kas = new dbkasaTable();
                if (kas.Kasa < Convert.ToDecimal(label7.Text))
                {
                    MessageBox.Show("Kasada yeterli bakiye yok!");
                    return;
                }
                kas.Kasa -= Convert.ToDecimal(Convert.ToDecimal(label7.Text));

                TemizleForm();
                DoluKoltuklariYukle();
                RadioButtonlariAyarla();
            }
            catch (Exception excep)
            {
                MessageBox.Show("Bir hata oluştu: " + excep.Message);
            }
        }

        public void rezervasyoncancel()
        {
            throw new NotImplementedException();
        }
    }
}