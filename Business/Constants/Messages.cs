using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductDeleted = "Urun silindi ";
        public static string ProductAdded = "Ürün eklendi";
        public static string IdEror = "ID hatalı";
        public static string PriceEror = "Hatali ucret girisi";
        public static string ProductUpdated = "Urun Guncellendi";
        public static string NameEror = "Isim hatasi";
        public static string ReturnDateEror = "Urun daha once kiralanmmis";
        public static string EntitiesListed = "Listeleme Islemi Tamamlandi! ";

        public static string CarImageLimitExceeded = "Araba resim limiti asildi";

        public static string UnsupportedMediaType = "Desteklenmeyen dosya turu";

        public static string CheckIdOrPath = "Id yi veya pathi kontrol edin";
        public static string AuthorizationDenied = "Yetki Hatasi";

        public static string UserRegistered = "Kullanici kayit edildi";
        public static string UserNotFound = "Kullanici bulunamadi";

        public static string WrongPassword = "Hatali Parola ";

        public static string LoginSuccessful = "Giris basarili";

        public static string UserExist = "Kullanici Mevcut";

        public static string TokenCreated = "Token Olusturuldu";

        public static string DefaultImageUploaded = "varsayilan resim yuklendi";
    }
}
