using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//global _değişken
        public InMemoryProductDal()
        {
            //Oracle,Sql Server,Postgres, MongoDb
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName = "Bardak", UnitPrice = 15 , UnitsInStock = 15},
                new Product{ProductId=2, CategoryId=1, ProductName = "Kamera", UnitPrice = 500 , UnitsInStock = 3},
                new Product{ProductId=3, CategoryId=2, ProductName = "Telefon", UnitPrice = 1500 , UnitsInStock = 2},
                new Product{ProductId=4, CategoryId=2, ProductName = "Klavye", UnitPrice = 150 , UnitsInStock = 65},
                new Product{ProductId=5, CategoryId=2, ProductName = "Fare", UnitPrice = 85 , UnitsInStock = 1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)//benim gönderdiğim product ... _product=> listedeki product
        {
            //LINQ - Languge Integrated Query
            //Lambda =>
                                                                //o an dolaşılan  //Gönderilen product
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);//Tek bir eleman bulmaya yarar product'sı tek tek Dolaşmaya yarar
                                            //foreach               //Kural
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //yeni bir liste haline getirip döndürür
        }

        public void Update(Product product)//gelen data
        {
            //Gönderdiğm ürün id'sine sahip olan listedeki ürünü bul'ki güncelle...
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
