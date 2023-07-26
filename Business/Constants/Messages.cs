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

        //Rental
        public static string InvalidRental = "Arabanın teslim tarihi bilgisi boş olamaz";
        
        //CarImage
        public static string CarImageLimitExceeded="Maksimum resim sayısına ulaşıldı!";
        public static string ImageAdded="Resim eklendi";
        public static string ImageOfCarNotFound="Arabanın resmi bulunamadı";
    }
}
