# 🚌 Otobüs Bilet Rezervasyon Sistemi

Bu proje, C# Windows Forms ve SQL Server kullanılarak geliştirilen bir **Otobüs Bilet Rezervasyon Uygulamasıdır**. Kullanıcılar otobüs seferlerini görebilir, koltuk seçimi yapabilir, rezervasyon oluşturabilir ve iptal işlemleri gerçekleştirebilir. Aynı zamanda sistemde kasa takibi de yapılmaktadır.

---

## 📦 Özellikler

- **🗺️ İller arası mesafe tablosu (belirli iller)
- **🚍 Sefer oluşturma ve görüntüleme
- **🎫 Koltuk seçimi ve rezervasyon
- **👤 Müşteri bilgileri kaydı
- **💰 Rezervasyon iptalinde ücret kasaya eklenir (trigger destekli)
- **📊 DataGridView üzerinden çift tıklamayla rezervasyon bilgilerini görme

---

## 🛠️ Kullanılan Teknolojiler

- **C# / .NET Framework**
- **Windows Forms**
- **SQL Server (SSMS)**
- **Entity Framework (Veritabanı bağlantısı)

---

## 🧰 Veritabanı Yapısı

- **`dberzervasyonTable` → Rezervasyon bilgileri
- **`dbmusTeriTable` → Müşteri kayıtları
- **`dbseferTable` → Sefer bilgileri
- **`dboTobusTable` → Otobüsler
- **`dbkolTukTable` → Koltuk numaraları
- **`dbkasaTable` → Kasa (trigger ile güncellenir)
- **`dbsehirTable` → İller arası mesafeler

---

## ⚙️ Trigger Özelliği

- **Rezervasyon silindiğinde, ücret `dbkasaTable` tablosuna otomatik olarak eklenir.

- **Rezervasyon eklendiğinde, ücret `dbkasaTable` tablosundan otomatik olarak eksilir.

- **Rezervasyon silindiğinde, koltuk sayısı `dboTobusTable` tablosuna otomatik olarak eklenir.

- **Rezervasyon eklendiğinde, koltuk sayısı `dboTobusTable` tablosundan otomatik olarak silinir

```
TRIGGER: TR_RezervasyonSilinceKasaEkle
TRIGGER: TR_RezervasyonYapıncaKasaEkle
TRIGGER: TR_RezervasyonİptalYapıncaKolTukSayısıArTması
TRIGGER: TR_RezervasyonYapıncaKolTukSayısıAzalması

