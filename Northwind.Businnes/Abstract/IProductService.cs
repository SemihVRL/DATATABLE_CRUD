using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Businnes.Abstract
{
    public interface IProductService
    {
        
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByProductName(string productName);
        void Add(Product product);
        void Updated(Product product);
        void Delete(Product product);
        
    }

}
