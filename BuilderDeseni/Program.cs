using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.ReadLine();
        }
    }

    public class ProducViewtModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProducViewtModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProducViewtModel model = new ProducViewtModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "CHILD";
            model.ProductName = "TSHIRT";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }
        public override ProducViewtModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProducViewtModel model = new ProducViewtModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "CHILD";
            model.ProductName = "TSHIRT";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = false;
        }
        public override ProducViewtModel GetModel()
        {
            return model;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}