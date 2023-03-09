1.sql.txt dosyasını çalıştır.

2.core için gerekli olan 4 tane paket vardı bunları ekle.
-entityframeworkcore
-entityframeworkcore.tools
-entityframeworkcore.sqlserver
-entityframeworkcore.design 

3.aşağıdaki kodu kendi sqlserver adresine göre değiştir.  
Scaffold-DbContext "Server=DESKTOP-864OGI4\SQLEXPRESS;Database=AdventureWorks2019;Trusted_Connection=True;Encrypt=False" 
  Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

4.bu işlemler sonucunda kendisi bir context classı oluşturur. bu class bizim için veri tabanına gitmenin yoludur.

5.yeni bir ekran tasarlayıp kategorileri ekrana yazdırıp, kullanıcı hangi kategoriyi seçerse o kategoriden random bir kelime alır getirir, onu ekrana dizeriz.

-------------

Uye dediğimiz :  kelimeleri güncelleyen ya da oyun oynayan sokaktaki adam olabilir.


Uye 2 rolü olsun.
1. admin (kelime ekleyecek.)
2. gamer

1 üyenin 1den fazla rolü olur mu?
evet
1 rolde 1den fazla üye olur mu?
evet

uye
rol
uyerol

use KelimelikDB

--Uye
--id,username,sifre,uyeolmatarihi
create table Uye
(
id int primary key identity,
username nvarchar(10),
sifre nvarchar(10),
uyeolmatarihi datetime default getdate()
)
--Rol
--id,ad
create table Rol
(
id int primary key identity,
ad nvarchar(10)
)
--UyeRol
--id,uyeid,rolid
create table UyeRol
(
id int primary key identity,
uyeid int,
rolid int
)

--tablolara kayıt eklemek için aşağıdaki kodları yazdık.
insert into Rol values ('admin'),('gamer')
insert into Uye (username,sifre) values('admin','123')
insert into UyeRol values (1,1)




---notlar

c# 
private GameObject object;
-unity
void Start()
{
 //unity kodları
}

void Update()
{
 //unity
}
-web developer (front end)
-backend (api ve c# )
-mobile (xamarin-maui)

----
--github hesabı açma - değiştirdiğimiz kodları gönderme
https://nagihanesendal.blogspot.com/2022/05/githubaprojegonderme.html













