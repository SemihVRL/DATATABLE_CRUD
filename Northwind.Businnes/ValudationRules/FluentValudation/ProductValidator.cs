using FluentValidation;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Businnes.ValudationRules.FluentValudation
{
    public class ProductValidator : AbstractValidator<Product>
    {   
        //fluent validation

        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("ürün ismi boş olamaz");//boş olamaz kodu bu
            RuleFor(p => p.CategoryID).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);//0dan büyük olması
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);//grater than ilk etapta 0 dan büyük olması daha sonra değişebilir//sgort yazma sebebimiz int 16 olduğu için
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p=>p.CategoryID==2);//ıd 2 olunca unıt price min 10 dan büyük olması gerekiyor

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürün a ile başlamalı");//startwitha bir isim ama bir method adıdır
        }

        private bool StartWithA(string arg) 
        {
            return arg.StartsWith("A");//func alan return edilir
        }
    }
}
