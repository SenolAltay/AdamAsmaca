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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        KelimelikDbContext veritabani = new KelimelikDbContext();
        private void button1_Click(object sender, EventArgs e)
        {
            //girilen kullanıcı adı ve şifre bilgisini tabloya bakıp böyle bir user var mı kontrol edelim
            Uye gelenUye= veritabani.Uyes.Where(satir => satir.Username == textBox1.Text && satir.Sifre == textBox2.Text).FirstOrDefault();   
            if (gelenUye != null)
            {
                //-eğer böyle bir user varsa onun rolünü alalım.
                int uyeId=gelenUye.Id;
                //   rolü admin ise kelime eklemek için form açalım.
                var rolid= veritabani.UyeRols.Where(satir => satir.Uyeid == uyeId).FirstOrDefault().Rolid;
                if(rolid==1)
                {
                    //admin
                    //MessageBox.Show("admin kelime ekleme sayfası oluşturulacak.");
                    KelimeEkleme kelimeEkleme = new KelimeEkleme();
                    kelimeEkleme.ShowDialog();


                }
                else
                {
                    //   rolü admin değilse oyun kategorisi seçtiğimiz ekranı açalım.
                    AnaForm anaform = new AnaForm();
                    anaform.ShowDialog();
                    this.Hide(); //?
                }
            }
            else 
            {
                //böyle bir user yoksa bu durumda uye olabilmesi için uye olma yani register dediğimiz formu açalım.
                UyeEkleme uyeEkleme = new UyeEkleme();
                uyeEkleme.ShowDialog();
            }

        }
    }
}
