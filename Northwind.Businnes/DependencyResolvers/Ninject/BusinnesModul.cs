using Ninject.Modules;
using Northwind.Businnes.Abstract;
using Northwind.Businnes.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Businnes.DependencyResolvers.Ninject
{
    public class BusinnesModul : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();

        }
    }
}
