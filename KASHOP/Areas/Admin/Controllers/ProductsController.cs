using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KASHOP.Data;
using KASHOP.Models;
using KASHOP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KASHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View(new Product());
        }
        public IActionResult Store(Product request, IFormFile Image)
        {
            if(Image != null && Image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images",fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    Image.CopyTo(stream);
                }
                request.Image = fileName;
            }
            if (ModelState.IsValid)
            {
                context.Products.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create",request);
        }
        public IActionResult Remove(int id)
        {
            var product = context.Products.Find(id);
            context.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}