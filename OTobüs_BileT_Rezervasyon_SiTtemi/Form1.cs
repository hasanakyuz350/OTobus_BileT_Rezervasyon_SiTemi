using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTobüs_BileT_Rezervasyon_SiTtemi
{
    public partial class Form1 : Form
    {
        static OTobüs_BileT_Rezervasyon_SiTtemiEntities db = new OTobüs_BileT_Rezervasyon_SiTtemiEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(comboBox3.Text.Trim(), out int girilenGun) ||
                !int.TryParse(comboBox4.Text.Trim(), out int girilenAy) ||
                !int.TryParse(comboBox5.Text.Trim(), out int girilenYil))
            {
                MessageBox.Show("Lütfen geçerli bir gün, ay ve yıl girin.");
                return;
            }

            DateTime girilenTarih;
            try
            {
                girilenTarih = new DateTime(girilenYil, girilenAy, girilenGun);
            }
            catch
            {
                MessageBox.Show("Geçersiz tarih girdiniz.");
                return;
            }

            bool eslesendaTe = db.dbseferTable.Any(x =>
                x.daTe.HasValue &&
                x.daTe.Value.Day == girilenTarih.Day &&
                x.daTe.Value.Month == girilenTarih.Month &&
                x.daTe.Value.Year == girilenTarih.Year);

            var eslesensehir = db.dbsehirTable.Count(x =>
                x.sehir1 == comboBox2.Text && x.sehir2 == comboBox1.Text);

            string nereden = comboBox2.Text;
            string nereye = comboBox1.Text;

            if (eslesendaTe && eslesensehir > 0)
            {
                Form2 form = new Form2(nereden, nereye, girilenTarih);
                form.Show();
            }
            else
            {
                MessageBox.Show("Hiç eşleşen kayıt bulunamadı.");
            }
        }
    }
}
