using AdamAsmaca.Models;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        public int kategoriId; //public: heryerden eriþilen anlamýna gelir.
        public Form1()
        {
            InitializeComponent();
        }       
        Label[] harfler;  //tutulan metnin harflerini saklamak için
        private void EkranaKelimeyiDiz(string kelime)
        {
            int x = 70, y = 100;
            harfler = new Label[kelime.Length];
            for (int i = 0; i < kelime.Length; i++)
            {
                Label label = new Label();
                label.Location= new Point(x, y);
                label.Size = new Size(20, 30);
                label.Text = "_";
                this.Controls.Add(label);
                harfler[i] = label; //tutulan meslek neyse onun harflerini diziye atadýk.
                x += 30; //harfleri yan yana koyacak.
            }
        }
        int hata = 0; //yaptýgým hatalarýn sayýsýný tutacak
        string meslek; //global alanda deðiþken tanýmladýk ki diðer metot üzerinden bu deðiþkenin deðerine eriþebilelim.

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(kategoriId.ToString());
            //meslek = RastgeleKelimeSec();
            meslek=VeritabanindanKelimeSec();
            //harfler dizisi kelimenin harfleri ile doldurulacak.
            //MessageBox.Show(meslek);
            EkranaKelimeyiDiz(meslek);
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage; //fotografý picturebox boyutuna sýgdýr dedik.
            pictureBox1.ImageLocation = "Adam\\0.png";


            //random sýrada harfler gelsin gösterilsin istersek aþaðýdaki kodlar
            //string harfler = "abcçdefgðhýijklmnoöprsþtuüvyz";            
            //int xKoordinatDegeri = 20, yKoordinatDegeri = 20;
            //int i;
            //for (int k = 0; k < harfler.Length; k++)
            //{
            //    Random rastgele = new Random();
            //    i = rastgele.Next(0, 29);                
            //    Button btn = new Button();
            //    btn.Location = new Point(xKoordinatDegeri, yKoordinatDegeri);
            //    btn.Text = harfler[i].ToString();
            //    btn.Width = 35;  //geniþlik
            //    btn.Height = 35; //yükseklik
            //    btn.Click += tiklananiBul;
            //    this.Controls.Add(btn);
            //    xKoordinatDegeri += btn.Width;               
            //}

            string harfler = "abcçdefgðhýijklmnoöprsþtuüvyz";
            int xKoordinatDegeri = 20, yKoordinatDegeri = 20;
            for (int i = 0; i < (harfler.Length / 2); i++)
            {
                Button btn = new Button();
                btn.Location = new Point(xKoordinatDegeri, yKoordinatDegeri);
                btn.Text = harfler[i].ToString();
                //string'in i.sýrasýndaki deðeri alýr ve btn.text'e atar.
                btn.Width = 35;  //geniþlik
                btn.Height = 35; //yükseklik
                btn.Click += Btn_Click;
                //btn.click += yazýp tab tuþuna 2 kez basarsak bize metot oluþturur ve bu metodu baðlar.
                this.Controls.Add(btn);
                xKoordinatDegeri += btn.Width;
            }
            xKoordinatDegeri = 20; yKoordinatDegeri += 35;
            for (int i = (harfler.Length / 2); i < (harfler.Length); i++)
            {
                Button btn = new Button();
                btn.Location = new Point(xKoordinatDegeri, yKoordinatDegeri);
                btn.Text = harfler[i].ToString();
                //string'in i.sýrasýndaki deðeri alýr ve btn.text'e atar.
                btn.Width = 35;  //geniþlik
                btn.Height = 35; //yükseklik
                btn.Click += Btn_Click;
                this.Controls.Add(btn);
                xKoordinatDegeri += btn.Width;
            }
            //random yardýmýyla harfleri karýþýk sýrada diziniz.
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;    //kimden týklamýþssak onun bilgisi sender içinde tutulur.
            //Button btn1 = (Button)sender;    
            string secilenHarf = btn.Text;
            btn.Enabled = false; // eðer buttona týklanmýþsa iþ insaný tekrar týklayamasýn diye buttonu kullanýlmaz hale getirdik.
            btn.Visible= false;  // buttonu görünmez yaptýk

            if (meslek.Contains(secilenHarf)) //meslek içerisinde benm buttondan seçtiðim harf var mý diye bakýyorum
            {
                //meslek içerisinde tek tek dönüp, secilen harfi bulup ekranda o harfi gösterme
                //1.döngü 
                //2.eðer secilen harf varsa yerini bul ve aç
                for (int i = 0; i < meslek.Length; i++) //her bir harfe tek tek gittik. 
                {
                    if (meslek[i].ToString() == secilenHarf)
                    {
                        //harfler dizisinden onu aç.
                        harfler[i].Text = secilenHarf; //o harfi atama iþlemi yap.
                        if (OyunBittiMi() == true)
                        {
                            MessageBox.Show("tebrikler kazandýnýz :)"+ meslek );
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                //hata yaptýk, yani o harfi bulamadýk bu durumda hata deðeri 1 artacak ardýndan pictureboxdaki fotografýn görseli deðiþtirilecek.
                hata++;
                pictureBox1.ImageLocation = "Adam\\" + hata + ".png";
                if (hata == 6)
                {
                    MessageBox.Show("oyun bitti " +meslek);
                    this.Close();
                }
            }
            //secilen harf tutulan metinde
            //MessageBox.Show(secilenHarf);
        }

        //geriye string  dönen ve random bir metin seçen metot.
        private string RastgeleKelimeSec()
        {
            //doktor,polis,yazýlýmcý,köfteci,operatör,diþçi,aþçý,kasiyer,öðretmen,futbolcu,pizzacý
            string[] meslekler = { "doktor", "polis", "developer", "operatör", "diþçi", "aþçý", "kasiyer", "öðretmen", "futbolcu" };
            int meslekAdedi = meslekler.Length;
            Random rastgele = new Random();
            int siraNo = rastgele.Next(0, meslekAdedi);
            return meslekler[siraNo];
        }

        //yeni bir metot yazalým.
        //kategoriid deðeri kullanýlarak daha önce yazdýgýmýz aþaðýdaki sorguyu metotlaþtýralým.
        ////kelimeler tablosundan kategoriid bilgisi yukarýdaki kategoriid ile eþleþen kayýtlarýn hepsini getirip ekrana mbox ile yazalým
        private string VeritabanindanKelimeSec()
        {
            KelimelikDbContext veritabani = new KelimelikDbContext();
            List<Kelime> liste = veritabani.Kelimes.Where(satir => satir.Kategoriid == kategoriId).ToList();

            Random rastgele = new Random();
            int secilecekElemanSiraNo=rastgele.Next(0, liste.Count + 1);
            return liste[secilecekElemanSiraNo].Ad;
        }



        private bool OyunBittiMi()
        {
            for (int i = 0; i < harfler.Length; i++)
            {
                if (harfler[i].Text == "_")
                {
                    //oyun oynanacak daha açýlmayan harfler var
                    return false;
                }
            }
            return true;
        }
      
    }
}