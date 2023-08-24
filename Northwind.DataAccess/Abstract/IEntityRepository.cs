using Northwind.Entity.Abstract;

using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        void Add(T entity);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T entity);
        void update(T entity);
    }

}
