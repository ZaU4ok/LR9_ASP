using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LR9_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR9_ASP
{
    public class ProductController : Controller
    {
        public IActionResult DisplayProducts()
        {
            var products = new List<Product>
        {
            new Product { ID = 1, Name = "Product 1", Price = 10.99m },
            new Product { ID = 2, Name = "Product 2", Price = 20.49m },
            new Product { ID = 3, Name = "Product 3", Price = 15.75m }
        };

            return View("ProductsView", products);
        }
    }
}
