using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C# -- araştır...
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //yer bulur - referansı yakalar
                addedEntity.State = EntityState.Added;//eklencek nesne set et
                context.SaveChanges();//Şimdi ekle
            }//using bitince direkt bellekten atılır
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //yeri bulur - referansı yakalar
                deletedEntity.State = EntityState.Deleted;//silenecek nesne, set et
                context.SaveChanges();//Şimdi sil
            }//using bitince direkt bellekten atılır
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //yeri bulur - referansı yakalar
                updatedEntity.State = EntityState.Modified;//Güncellenicek nesne, set et
                context.SaveChanges();//Şimdi Güncelle
            }//using bitince direkt bellekten atılır
        }
    }
}
