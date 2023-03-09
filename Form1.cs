using AdamAsmaca.Models;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        public int kategoriId; //public: heryerden eri�ilen anlam�na gelir.
        public Form1()
        {
            InitializeComponent();
        }       
        Label[] harfler;  //tutulan metnin harflerini saklamak i�in
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
                harfler[i] = label; //tutulan meslek neyse onun harflerini diziye atad�k.
                x += 30; //harfleri yan yana koyacak.
            }
        }
        int hata = 0; //yapt�g�m hatalar�n say�s�n� tutacak
        string meslek; //global alanda de�i�ken tan�mlad�k ki di�er metot �zerinden bu de�i�kenin de�erine eri�ebilelim.

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(kategoriId.ToString());
            //meslek = RastgeleKelimeSec();
            meslek=VeritabanindanKelimeSec();
            //harfler dizisi kelimenin harfleri ile doldurulacak.
            //MessageBox.Show(meslek);
            EkranaKelimeyiDiz(meslek);
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage; //fotograf� picturebox boyutuna s�gd�r dedik.
            pictureBox1.ImageLocation = "Adam\\0.png";


            //random s�rada harfler gelsin g�sterilsin istersek a�a��daki kodlar
            //string harfler = "abc�defg�h�ijklmno�prs�tu�vyz";            
            //int xKoordinatDegeri = 20, yKoordinatDegeri = 20;
            //int i;
            //for (int k = 0; k < harfler.Length; k++)
            //{
            //    Random rastgele = new Random();
            //    i = rastgele.Next(0, 29);                
            //    Button btn = new Button();
            //    btn.Location = new Point(xKoordinatDegeri, yKoordinatDegeri);
            //    btn.Text = harfler[i].ToString();
            //    btn.Width = 35;  //geni�lik
            //    btn.Height = 35; //y�kseklik
            //    btn.Click += tiklananiBul;
            //    this.Controls.Add(btn);
            //    xKoordinatDegeri += btn.Width;               
            //}

            string harfler = "abc�defg�h�ijklmno�prs�tu�vyz";
            int xKoordinatDegeri = 20, yKoordinatDegeri = 20;
            for (int i = 0; i < (harfler.Length / 2); i++)
            {
                Button btn = new Button();
                btn.Location = new Point(xKoordinatDegeri, yKoordinatDegeri);
                btn.Text = harfler[i].ToString();
                //string'in i.s�ras�ndaki de�eri al�r ve btn.text'e atar.
                btn.Width = 35;  //geni�lik
                btn.Height = 35; //y�kseklik
                btn.Click += Btn_Click;
                //btn.click += yaz�p tab tu�una 2 kez basarsak bize metot olu�turur ve bu metodu ba�lar.
                this.Controls.Add(btn);
                xKoordinatDegeri += btn.Width;
            }
            xKoordinatDegeri = 20; yKoordinatDegeri += 35;
            for (int i = (harfler.Length / 2); i < (harfler.Length); i++)
            {
                Button btn = new Button();
                btn.Location = new Point(xKoordinatDegeri, yKoordinatDegeri);
                btn.Text = harfler[i].ToString();
                //string'in i.s�ras�ndaki de�eri al�r ve btn.text'e atar.
                btn.Width = 35;  //geni�lik
                btn.Height = 35; //y�kseklik
                btn.Click += Btn_Click;
                this.Controls.Add(btn);
                xKoordinatDegeri += btn.Width;
            }
            //random yard�m�yla harfleri kar���k s�rada diziniz.
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;    //kimden t�klam��ssak onun bilgisi sender i�inde tutulur.
            //Button btn1 = (Button)sender;    
            string secilenHarf = btn.Text;
            btn.Enabled = false; // e�er buttona t�klanm��sa i� insan� tekrar t�klayamas�n diye buttonu kullan�lmaz hale getirdik.
            btn.Visible= false;  // buttonu g�r�nmez yapt�k

            if (meslek.Contains(secilenHarf)) //meslek i�erisinde benm buttondan se�ti�im harf var m� diye bak�yorum
            {
                //meslek i�erisinde tek tek d�n�p, secilen harfi bulup ekranda o harfi g�sterme
                //1.d�ng� 
                //2.e�er secilen harf varsa yerini bul ve a�
                for (int i = 0; i < meslek.Length; i++) //her bir harfe tek tek gittik. 
                {
                    if (meslek[i].ToString() == secilenHarf)
                    {
                        //harfler dizisinden onu a�.
                        harfler[i].Text = secilenHarf; //o harfi atama i�lemi yap.
                        if (OyunBittiMi() == true)
                        {
                            MessageBox.Show("tebrikler kazand�n�z :)"+ meslek );
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                //hata yapt�k, yani o harfi bulamad�k bu durumda hata de�eri 1 artacak ard�ndan pictureboxdaki fotograf�n g�rseli de�i�tirilecek.
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

        //geriye string  d�nen ve random bir metin se�en metot.
        private string RastgeleKelimeSec()
        {
            //doktor,polis,yaz�l�mc�,k�fteci,operat�r,di��i,a���,kasiyer,��retmen,futbolcu,pizzac�
            string[] meslekler = { "doktor", "polis", "developer", "operat�r", "di��i", "a���", "kasiyer", "��retmen", "futbolcu" };
            int meslekAdedi = meslekler.Length;
            Random rastgele = new Random();
            int siraNo = rastgele.Next(0, meslekAdedi);
            return meslekler[siraNo];
        }

        //yeni bir metot yazal�m.
        //kategoriid de�eri kullan�larak daha �nce yazd�g�m�z a�a��daki sorguyu metotla�t�ral�m.
        ////kelimeler tablosundan kategoriid bilgisi yukar�daki kategoriid ile e�le�en kay�tlar�n hepsini getirip ekrana mbox ile yazal�m
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
                    //oyun oynanacak daha a��lmayan harfler var
                    return false;
                }
            }
            return true;
        }
      
    }
}