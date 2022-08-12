using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //static verildiğinde new'lemiyoruz
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz"; //public'ler pascal case yazılır
        public static string MaintenanceTime = "Sitem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Kategorideki ürün sayısını aştınız";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşılıdığı için yeni ürün ekleyemezsiniz";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
