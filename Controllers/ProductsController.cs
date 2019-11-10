using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory_MVC.Models;

namespace Product_Inventory_MVC.Controllers
{
    //Manages products with Authorization.
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly Product_Inventory_MVCContext _context;

        public ProductsController(Product_Inventory_MVCContext context)
        {
            _context = context;
        }

        // GET: Products
        //Gets all products using a lamda query.
        public IActionResult Index()
        {
            var product_Inventory_MVCContext = _context.Product.Include(p => p.ProductCategory);
            return View( product_Inventory_MVCContext.ToList());
        }

        // GET: Products/Details/5
        //Returns the details of the product using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  _context.Product
                .Include(p => p.ProductCategory)
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        //Gets the create products form.
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.Set<ProductCategory>(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creats the product.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProductName,Price,ProductCategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.Set<ProductCategory>(), "Id", "Id", product.ProductCategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        //Gets the product for update using a lamda query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = (from products in _context.Product
                           where products.Id == id
                           select products).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.Set<ProductCategory>(), "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates a product.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ProductName,Price,ProductCategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.Set<ProductCategory>(), "Id", "Id", product.ProductCategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        //Gets a product for delete  uses a lamda query to get the product.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  _context.Product
                .Include(p => p.ProductCategory)
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        //Removes the product from database. uses a linq query to get the product.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = (from products in _context.Product
                           where products.Id == id
                           select products).FirstOrDefault();
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Checka the product for existance using a lamda query.
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
