using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new() //kurallar
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C# -- araştır...
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //yer bulur - referansı yakalar
                addedEntity.State = EntityState.Added;//eklencek nesne set et
                context.SaveChanges();//Şimdi ekle
            }//using bitince direkt bellekten atılır
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //yeri bulur - referansı yakalar
                deletedEntity.State = EntityState.Deleted;//silenecek nesne, set et
                context.SaveChanges();//Şimdi sil
            }//using bitince direkt bellekten atılır
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //yeri bulur - referansı yakalar
                updatedEntity.State = EntityState.Modified;//Güncellenicek nesne, set et
                context.SaveChanges();//Şimdi Güncelle
            }//using bitince direkt bellekten atılır
        }
    }
}
