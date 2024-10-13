# Online Ticari Otomasyon Projesi

## **Genel Bakış**

 :star:Kullanıcıların eklenen ürünleri görmesi, sipariş geçmişini görebilmesi, kargo hareketlerini takip edebilmesi, kullanıcılara mesaj gönderebilmesi; Admin tarafında personel ekleme, dinamik fatura ekleme gibi pek çok özellikler eklenerek bir Ticari Otomasyon simülasyonu oluşturuldu.

### 🙇[**Kullanıcı Tarafı**](#kullanici-paneli) :bow:

Login Paneli'nde kayıt olduktan sonra Cari Girişi yaparak sisteme girilir.

 :pushpin:**Profilim**, siteden yaptığı toplam satış tutarını, ürün sayısını, kişisel bilgilerini görebilir.

<li>Kendisine diğer Carilerden gelen mesajları görüntüleyebilir.

<li>Admin tarafından eklenen Duyuruları görebilir.

<li>Ayarlar kısmında kendi bilgilerini, şifresini güncelleyebilir.

 :pushpin:**Siparişlerim**, sipariş geçmişini görüntüleyebilir.

 :pushpin:**Kargo Takibi**, girilen kargo takip numarası ile kargosunun hareketine dair bilgileri görüntüleyebilir. 

 :pushpin:**Mesajlar**, diğer Carilerden gelen mesajları görüntüleyebilir, yeni mesaj gönderebilir.

 :pushpin:**Çıkış Yap** sistemden çıkış yapar.
 

### 💎[**Admin Tarafı**](#admin-paneli)💎

Login Paneli'nde Personel Girişi yaparak sisteme girilir.

✔️ **Kategoriler**, mevcut kategorileri listeler, güncelleme ve silme işlemi yapabilir ve yeni kategori ekleyebilir.

:heavy_check_mark: **Ürünler**, ürünleri listeler, arama yaparak istenen ürüne ulaşılabilir. Güncelleme/Silme/Yeni ürün ekleme işlemleri yapılabilir.

:wavy_dash: Satış Yap butonu ile o ürünün satış işlemi gerçekleştirilebilir.

:heavy_check_mark:**Departmanlar**, Ekle/Sil/Güncelleme işlemleri yapılabilir. Detaylar butonu ile o departmandaki personel listelenebilir.

:wavy_dash:	Satışlar butonu ile personelin yaptığı satışlar listelenir.

:heavy_check_mark:**Cariler**, cariler listelenir. Ekle/Sil/Güncelleme işlemleri yapılabilir.

:wavy_dash:	Satış Geçmişi butonu ile o carinin satın alma geçmişi görüntülenir.

:heavy_check_mark:**Personeller**, personeller üzerinde Ekle/Sil/Güncelle işlemleri yapılabilir. Detaylar ile personelin satış geçmişi görüntülenir.

:heavy_check_mark:**Personel Tablosu**, tüm personeller listelenir. Butonlar aracılığıyla personel bilgisi güncellenebilir, satış geçmişne gidilebilir.

:heavy_check_mark:**Grafikler**, Google Chart kullanılarak Ürün-Stok yüzdeleri Pie,Column ve Line grafik olarak listelenir.

:heavy_check_mark:**Faturalar**, carilere kesilen faturalar listelenir. Popup penceresi olarak da listelenebilir.

:wavy_dash:	Faturaya Ekle/Güncelle işlemleri yapılabilir.

:wavy_dash:Tıklanan faturaya Yeni Kalem girişi yapılabilir.

:heavy_check_mark:**Dinamik Faturalar**, fatura ve kalem bilgileri listelenir. Yeni fatura girişi yapılabilir.

:heavy_check_mark:**Satışlar**, yapılan satışları listeler. Güncelle/Detaylar/Yeni Satış işlemleri yapılabilir.

:heavy_check_mark:**Giderler**, sayfa bulunamadığında Error sayfası görüntülenir. Anasayfaya dönülebilir.

:heavy_check_mark:**Kargolar**, kargolar listelenir. Takip numarası ile kargoya ait bilgiler aranabilir. Detayları görüntüleyip yeni kargo girişi yapılabilir.

:heavy_check_mark:**PDF-Excel**, sekmesi ile istenilen sütun bilgileri ile ürünlerin çıktısı alınabilir. 

:heavy_check_mark:**İstatistikler**, projeye ait istatistikler listelenir.

:heavy_check_mark:**Galeri**, ürünlerin görselleri listelenir.

:heavy_check_mark:**Hızlı Bakış**, Kategori Tablosu, Müşteri-Şehir Tablosu, Ürün-Marka Tablosu, Departman-Personel Sayıları, Cariler, Ürünler tablolar halinde listelenir.

## :crossed_swords: **Kullanılan Teknolojiler**

<table>
  <tr>
    <td>:moyai:Asp.Net MVC5 ile oluşturulmuş dinamik bir web site projesidir.</td>
    <td>:low_brightness:Partial Views</td>
  </tr>
  <tr>
    <td>🔎Code First yaklaşımı ile oluşturulmuştur.</td>
    <td>:battery:Modal Popup ve Alert kullanımı</td>
  </tr>
  <tr>
    <td>:ticket:Entity Framework</td>
    <td>:lock_with_ink_pen:Authentication ve Authorize işlemleri</td>
  </tr>
  <tr>
    <td>:airplane:MSSQL Server</td>
    <td>:bulb:Paging ve Arama işlemleri</td>
  </tr>
  <tr>
    <td>:stars:İlişkisel Tablolar üzerinde LINQ sorguları</td>
    <td>:electric_plug:QR kod oluşturma</td>
  </tr>
  <tr>
    <td>:ferris_wheel:Trigger ve Prosedür kullanımı</td>
    <td>:rice_scene:Google Chart kullanımı</td>
  </tr>
  <tr>
    <td>:sunrise:Validation Kontrolleri eklendi</td>
    <td>:sunflower:Error Page kullanımı</td>
  </tr>
  <tr>
    <td>:ribbon:DataTable kullanımı</td>
    <td>:maple_leaf:Widget Cards kullanımı</td>
  </tr>
</table>

## **Görseller**

:fishsticks: **VERİ TABANI MODELİ**

![46](https://github.com/user-attachments/assets/01d1770e-10d3-43cd-a16d-d972d33a12ad)

:last_quarter_moon_with_face: **LOGIN SAYFASI**

![1](https://github.com/user-attachments/assets/a5b23a4c-19e4-4777-a62d-a692055b3550)
![2](https://github.com/user-attachments/assets/096b9fbd-8a22-49ff-8527-d66382e43c71)
![3](https://github.com/user-attachments/assets/59738a88-8a19-4b0f-b629-ce425d6069d2)
![4](https://github.com/user-attachments/assets/bca31ba6-6a25-43c0-b325-ce788e0a5d8e)


:rainbow: **KULLANICI PANELİ**

![5](https://github.com/user-attachments/assets/1f39607e-4761-41ed-a2c5-5d4ae00ca6c3)
![6](https://github.com/user-attachments/assets/7e59c3cf-8184-4131-bb16-38a23d5a43ca)
![7](https://github.com/user-attachments/assets/5bbc91c5-c66b-4714-94fa-6017ac9eb37a)
![8](https://github.com/user-attachments/assets/f2a4ee29-8f13-42b8-a3e6-a85f875131bf)
![9](https://github.com/user-attachments/assets/a94cca79-bbcc-4690-977a-8914c4c6f54b)
![9_a](https://github.com/user-attachments/assets/4092bf23-ce18-4fdb-9fb4-b873909460d2)
![10](https://github.com/user-attachments/assets/1a745ac9-b2c9-4571-9196-658108166a82)
![11](https://github.com/user-attachments/assets/2f129cd5-f66d-4d44-bdfe-222cdc24e6ff)
![12](https://github.com/user-attachments/assets/51c371fe-2c98-4ba4-b6a2-6002c5bf1c6f)
![13](https://github.com/user-attachments/assets/048c5e00-7a56-4198-a3f8-a1c469767d3c)

:circus_tent:**ADMİN PANELİ**
 
![14](https://github.com/user-attachments/assets/bd5cf710-6e47-463f-b6b3-d47ecfb277da)
![15](https://github.com/user-attachments/assets/d7d94c21-38dd-446a-8127-56d80c5d0287)
![16](https://github.com/user-attachments/assets/3df66df1-c8c6-4c37-8453-01719144bd9f)
![17](https://github.com/user-attachments/assets/181d4c83-eda7-4ae5-ba42-c56d3f3638d2)
![18](https://github.com/user-attachments/assets/7ca15430-e114-498e-b61d-10a0ed6d73c3)
![19](https://github.com/user-attachments/assets/9db1fd40-5b2e-4fc5-9a10-a9deb8ab1cdb)
![20](https://github.com/user-attachments/assets/9862421f-5dca-417d-a483-e7c6216f24e7)
![21](https://github.com/user-attachments/assets/8da0f7c6-6ee8-4afa-accc-2cf317cb7605)
![22](https://github.com/user-attachments/assets/8086a2e6-e53b-417c-95fd-5104bb19ecd2)
![23](https://github.com/user-attachments/assets/300b1c87-1e15-4048-bd79-18fefc594bcf)
![24](https://github.com/user-attachments/assets/fb33178a-96c4-4b06-bf25-08cf87ba229f)
![25](https://github.com/user-attachments/assets/a12f0dd7-2b69-4976-968e-8d436b18f494)
![26](https://github.com/user-attachments/assets/534436d3-cd3f-4ef0-9db5-53f041cb93e7)
![27](https://github.com/user-attachments/assets/3abbc253-58b1-4cdf-8850-87a6c315c747)
![28](https://github.com/user-attachments/assets/ae50910c-4f4e-4eaa-9f19-afb04f9cfe62)
![29](https://github.com/user-attachments/assets/4f40b950-7563-4113-be0e-4553a1e9fef8)
![30](https://github.com/user-attachments/assets/d1571eaf-e5f4-4b24-ba7f-908707b66d6a)
![31](https://github.com/user-attachments/assets/ad191723-a8c2-400d-9a71-e97fe34a34c6)
![32](https://github.com/user-attachments/assets/2390aa2b-f782-47f9-8d14-9a0c15af3ba3)
![33](https://github.com/user-attachments/assets/4a10d109-1c6f-44db-8dc9-50b0350c230a)
![34](https://github.com/user-attachments/assets/65a8f18f-6d8c-4e57-b172-d35f051fa0e1)
![35](https://github.com/user-attachments/assets/f3e0fa6b-b48e-4f37-90a3-7cdd373841c7)
![36](https://github.com/user-attachments/assets/1d301b95-337c-49b5-9c62-701277cfc4df)
![37](https://github.com/user-attachments/assets/2e0a203a-d27e-41c8-aefe-407ac0dedb2a)
![38](https://github.com/user-attachments/assets/9a812c3b-3590-4a22-be33-c96e524f01d6)
![39](https://github.com/user-attachments/assets/79d142be-830c-4f79-a210-fd0e3b174bea)
![40](https://github.com/user-attachments/assets/1eff1af7-84e7-49e2-be78-a97b7dcb418e)
![41](https://github.com/user-attachments/assets/b7d62204-d7db-422c-9406-ed73b06ddc74)
![42](https://github.com/user-attachments/assets/8cafdd8e-ee5e-4634-a0be-29debf74d8d2)
![43](https://github.com/user-attachments/assets/f008f9cd-7705-4d5c-8403-b31ef6062763)
![44](https://github.com/user-attachments/assets/bee87d0b-93ce-493e-9cae-7501c1d9aa0a)
![45](https://github.com/user-attachments/assets/2bc43776-138c-40b3-ad8d-24632570a5c5)
