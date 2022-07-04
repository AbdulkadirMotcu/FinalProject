using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip
    //IEntity : IEntity olabilir yada IEntity implemente eden bir nesne olabilir...
    //new() : new'lenebilir olabilir -- IEntity new'lenemez interface olduğu için...
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//ürünleri getitirir filtere verebilir yada vermeyebilir...
        T Get(Expression<Func<T,bool>> filter); //filtre vermek zorunlu -- verinin detayına gider..
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
