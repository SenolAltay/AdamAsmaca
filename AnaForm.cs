using AdamAsmaca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            string[] kategoriler = { "meslekler", "meyveler", "eşyalar", "hayvanlar" };
            string[] fotografYollari = { "meslekler", "meyveler", "esyalar", "hayvanlar" };
            int x = 30, y = 40;
            for (int i = 0; i < 4; i++)
            {
                Button btn = new Button();
                btn.Text = kategoriler[i];   
                
                btn.BackgroundImageLayout = ImageLayout.Stretch; //fotograf button sınırlarına sıgacak sekilde küçültülür, böylece fotografın heryeri görünür.
                btn.BackgroundImage = Image.FromFile(
  Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
     "Adam/" + fotografYollari[i]+".jpg"));

                btn.Location = new Point(x, y);
                btn.Size = new Size(150,100 ); //70:genişlik(width) - 40:yukseklik(height)
                btn.Click += tiklananiBul; //btn.Click+= yaz 2 kez taba bas. metot adını değiştirmek istersen ctrl + r + r diyerek metotların adını, kullanıldıgı yerleri ve tanımlandıgı yeri değiştirebiliriz. bu metot buttona tıklanınca calışan metottur.

                this.Controls.Add(btn);
                x += btn.Width;
            }
        }

        private void tiklananiBul(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(btn.Text);
            var secilenDers = btn.Text;
            //mesleklerin arkadaki id değerini alıp bu id değerlerine göre buldugumuz kategorideki kelimeleri getirelim ve ekrana yazalım.
            KelimelikDbContext veritabani = new KelimelikDbContext();
            int secilenKategoriid = veritabani.Kategoris.Where(kelime => kelime.Ad == secilenDers).FirstOrDefault().Id;

            Form1 frm = new Form1();
            frm.kategoriId = secilenKategoriid; // bu formda seçilen kategorinin id değerini diğer forma public tanımlı değişken yardımıyla gönderdik, taşıdık
            frm.ShowDialog();
            //MessageBox.Show(kategoriId.ToString());





        }
    }
}
