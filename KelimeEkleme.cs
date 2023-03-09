using AdamAsmaca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class KelimeEkleme : Form
    {
        public KelimeEkleme()
        {
            InitializeComponent();
        }

        KelimelikDbContext veritabani = new KelimelikDbContext();
        private void KelimeEkleme_Load(object sender, EventArgs e)
        {
            //load: yüklemek: form yüklenmeden yani gözünün önüne çizdirilmeden önce bu metot çalışır.
            //köprüden önce son çıkış....
            //combobox içerisine kategoriler dolduralacak
            List<Kategori> kategoriler=veritabani.Kategoris.ToList();
            foreach (var item in kategoriler)
            {
                comboBox1.Items.Add(item.Ad); //kategoriler toplulugundaki her bir elemanı comboya ekler.
            }
        }
        string secilenKategori;
        private void button1_Click(object sender, EventArgs e)
        {
            //button click eventi : event = olayı çalışacak
            //1.seçilen kategorinin id değerini al
            int katid=veritabani.Kategoris.Where(satir => satir.Ad == secilenKategori).FirstOrDefault().Id;
            //2.girilen kelime değerini al
            string kelimeAd = textBox1.Text;
            if(veritabani.Kelimes.Where(satir=>satir.Ad==kelimeAd).FirstOrDefault()!=null)
            {
                MessageBox.Show("Bu kelime zaten ekli");
                textBox1.Clear();                
                comboBox1.Text = "Seçiniz";
            }
            else
            {
                //3.buttona tıklanınca bu bilgileri sqldeki kelime tablosuna ekle.
                Kelime kelime = new Kelime();
                kelime.Kategoriid = katid;
                kelime.Ad = kelimeAd;
                veritabani.Kelimes.Add(kelime);
                veritabani.SaveChanges();
                MessageBox.Show("Kelime başarılı bir şekilde sisteme kaydedildi.");
                textBox1.Clear();
                comboBox1.Text = "Seçiniz";
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenKategori = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(secilenKategori);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                this.BackColor = Color.Black;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                radioButton1.ForeColor = Color.White;
                radioButton2.ForeColor = Color.White;
                groupBox1.ForeColor= Color.White;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.BackColor = Color.Gray;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                groupBox1.ForeColor = Color.Black;
            }
        }
    }
}

