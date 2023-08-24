using Northwind.Businnes.Abstract;

using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Northwind.Businnes.ValudationRules.FluentValudation;
using Northwind.Businnes.Utilities;

namespace Northwind.Businnes.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        public ProductService(IProductDal productDal)

        {
            _productDal = productDal;
        }

       

        public void Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch(DbUpdateException e)
            {
                throw new Exception("silme gerçekleşemedi");
               
            }

        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryID == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Updated(Product product)
        {
            _productDal.update(product);
        }
    }
}
