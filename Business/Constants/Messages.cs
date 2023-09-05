using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Car
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Arabanın kaydı silindi";
        public static string CarUpdated = "Araba bilgileri güncellendi";
        public static string InvalidCarInfo = "Girdiğiniz bilgiler geçersiz tekrar deneyin";

        //Color
        public static string ColorAdded = "Renk eklendi";

        //Brand
        public static string BrandAdded = "Marka eklendi";

        //Rental
        public static string InvalidRental = "Arabanın teslim tarihi bilgisi boş olamaz";
        
        //CarImage
        public static string CarImageLimitExceeded="Maksimum resim sayısına ulaşıldı!";
        public static string ImageAdded="Resim eklendi";
        public static string ImageOfCarNotFound="Arabanın resmi bulunamadı";

        public static string AuthorizationDenied="Yetkilendirme hatası!";

        //Auth
        public static string AccessTokenCreated="Giriş yapıldı.";
        public static string UserAlreadyExists="Kullanıcı zaten kayıtlı";
        public static string UserRegistered="Kullanıcı kaydı yapıldı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string PasswordError="Hatalı parola";
        public static string UserNotFound="Kullanıcı bulunamadı";
    }
}
