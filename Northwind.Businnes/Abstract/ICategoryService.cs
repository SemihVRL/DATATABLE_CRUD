using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Businnes.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
