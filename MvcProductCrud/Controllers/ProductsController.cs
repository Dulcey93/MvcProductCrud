using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProductCrud.Models;
using MvcProductCrud.Data;
using MvcProductCrud.ViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;


namespace MvcProductCrud.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductsController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImagePath = p.ImagePath
                })
                .ToListAsync();

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ReleaseDate = p.ReleaseDate.ToString("d"),
                    ImagePath = p.ImagePath
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // CREATE: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName;

                if (model.Image != null)
                {
                    // Guardar la imagen
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // Imagen por defecto
                    uniqueFileName = "trolley.png"; // Nombre de archivo por defecto
                }

                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    ImagePath = "/images/" + uniqueFileName,
                    ReleaseDate = DateTime.Now // Asignar fecha de lanzamiento
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }




        // EDIT: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath // o el nombre correcto del campo imagen
            };

            return View(model); // 👈 Importante: enviamos el ViewModel
        }


        // EDIT: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            try
            {
                if (id != model.Id) return NotFound();

                if (!ModelState.IsValid) return View(model);

                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;

                if (model.Image != null)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    var newFilePath = Path.Combine(_hostEnvironment.WebRootPath, "images", uniqueFileName);

                    using (var stream = new FileStream(newFilePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    // Borrar imagen anterior
                    if (!string.IsNullOrEmpty(product.ImagePath))
                    {
                        var oldFileName = Path.GetFileName(product.ImagePath); // Extrae solo el nombre del archivo
                        var oldFilePath = Path.Combine(_hostEnvironment.WebRootPath, "images", oldFileName);

                        if (System.IO.File.Exists(oldFilePath))
                            System.IO.File.Delete(oldFilePath);
                    }

                    product.ImagePath = "/images/" + uniqueFileName;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Loggear el error a consola o mostrarlo en la vista temporalmente
                Console.Write("HOLA SOY EL ERROR: "+ex.Message);
                return Content("Ocurrió un error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }





        // DELETE: Products/Delete/5
        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            var viewModel = new ProductDeleteViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImagePath = product.ImagePath
            };

            return View(viewModel);
        }


        // DELETE: Products/Delete/5
        // POST

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            // Verificar si el producto existe
            if (product != null)
            {
                // Eliminar imagen del servidor si no es la imagen por defecto
                if (product.ImagePath != "/images/trolley.png" && product.ImagePath != null)
                {
                    string imagePath = Path.Combine(_hostEnvironment.WebRootPath, product.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
