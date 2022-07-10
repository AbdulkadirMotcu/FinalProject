﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
