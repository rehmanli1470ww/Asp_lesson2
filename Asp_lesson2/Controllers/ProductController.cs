using Asp_lesson2.Entities;
using Asp_lesson2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Asp_lesson2.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product()
            {
                Id = 1,
                Name = "Coca-Cola",
                Description = "Refreshing soft drink",
                Price = "1.5 AZN",
                Discount = "0.10 AZN"
            },
            new Product()
            {
                Id = 2,
                Name = "Pepsi",
                Description = "Popular cola beverage",
                Price = "1.4 AZN",
                Discount = "0.15 AZN"
            },
            new Product()
            {
                Id = 3,
                Name = "Fanta",
                Description = "Orange flavored soda",
                Price = "1.6 AZN",
                Discount = "0.20 AZN"
            },
            new Product()
            {
                Id = 4,
                Name = "Sprite",
                Description = "Lemon-lime flavored soft drink",
                Price = "1.5 AZN",
                Discount = "0.10 AZN"
            },
            new Product()
            {
                Id = 5,
                Name = "Mountain Dew",
                Description = "Citrus flavored soda",
                Price = "1.7 AZN",
                Discount = "0.25 AZN"
            },
            new Product()
            {
                Id = 6,
                Name = "Dr Pepper",
                Description = "Unique blend of 23 flavors",
                Price = "1.8 AZN",
                Discount = "0.30 AZN"
            },
            new Product()
            {
                Id = 7,
                Name = "7 Up",
                Description = "Clear lemon-lime soda",
                Price = "1.4 AZN",
                Discount = "0.05 AZN"
            },
            new Product()
            {
                Id = 8,
                Name = "Snapple",
                Description = "Variety of iced teas",
                Price = "2.0 AZN",
                Discount = "0.20 AZN"
            },
            new Product()
            {
                Id = 9,
                Name = "Gatorade",
                Description = "Electrolyte drink",
                Price = "2.5 AZN",
                Discount = "0.15 AZN"
            },
            new Product()
            {
                Id = 10,
                Name = "Red Bull",
                Description = "Energy drink",
                Price = "3.0 AZN",
                Discount = "0.50 AZN"
            }

        };
        public IActionResult Index()
        {
            var vm = new ProductListViewModel()
            {
                Products = Products
            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = Products.SingleOrDefault(e => e.Id == id);
            var vm = new ProductUpdate()
            {
                Product = item
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(ProductUpdate productUpdate)
        {
            var updatedProduct = productUpdate.Product;

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == updatedProduct.Id)
                {
                    Products[i] = updatedProduct;
                }
            }
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
           var item=Products.SingleOrDefault(e=>e.Id == id);
            if (item != null)
            {
                Products.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
