using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //soyut nesne ile bağlantı olmalı -- başka teknojilerde kullanılabilir olaması için

        public ProductManager(IProductDal productDal)//IProduct referansı verilir -- Constructor injection yapıldı...
        {
            _productDal = productDal;
        }
        //-----
        public List<Product> GetAll()
        {
            //İş kodları //iş kodların tamamı bir alana bağlı olamamsı gerekir -- BİR İŞ SINIFI BAŞKA SINIFLARI NEW'LEMEZ
            return _productDal.GetAll(); //ürünler verilir -- kurallardan geçti ise
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
