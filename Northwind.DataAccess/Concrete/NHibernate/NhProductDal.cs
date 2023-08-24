using Northwind.DataAccess.Abstract;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : IProductDal
    {   
     
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
              new Product
              {
                  ProductID=1,CategoryID=3,ProductName="semih",UnitPrice=1000,QuantityPerUnit="bilmiyorum"

              }
            };
            return products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
