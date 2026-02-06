using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KASHOP.Data;
using KASHOP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KASHOP.Areas.User.Controllers
{
    [Area("User")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = context.Products.Include(p=>p.Category).ToList();
            var productsVM = new List<ProductsViewModel>();
            foreach (var product in products)
            {
                var vm = new ProductsViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = $"/images/{product.Image}",
                    Price = product.Price,
                    CategoryName = product.Category.Name
                };
                productsVM.Add(vm);
            }
            return View(productsVM);
        }
    }
}