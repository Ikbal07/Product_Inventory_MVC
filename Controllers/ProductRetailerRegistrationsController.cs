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

    //Manages product retailler registration details.
    [Authorize]
    public class ProductRetailerRegistrationsController : Controller
    {
        private readonly Product_Inventory_MVCContext _context;

        public ProductRetailerRegistrationsController(Product_Inventory_MVCContext context)
        {
            _context = context;
        }

        // GET: ProductRetailerRegistrations
        //Gets all product retailer registrations using a lamda query.
        public IActionResult Index()
        {
            var product_Inventory_MVCContext = _context.ProductRetailerRegistration.Include(p => p.Product).Include(p => p.Retailer);
            return View( product_Inventory_MVCContext.ToList());
        }

        // GET: ProductRetailerRegistrations/Details/5
        //Gets prouduct details registration using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRetailerRegistration =  _context.ProductRetailerRegistration
                .Include(p => p.Product)
                .Include(p => p.Retailer)
                .FirstOrDefault(m => m.Id == id);
            if (productRetailerRegistration == null)
            {
                return NotFound();
            }

            return View(productRetailerRegistration);
        }

        // GET: ProductRetailerRegistrations/Create
        //Gets the registration form.
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
            ViewData["RetailerId"] = new SelectList(_context.Set<Retailer>(), "Id", "Name");
            ViewData["DeliveryStatus"] = new SelectList(Enum.GetValues(typeof(DeliveryStatus)));
            return View();
        }

        // POST: ProductRetailerRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Registers a product to a retailer.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,RetailerId,DeliveryStatus")] ProductRetailerRegistration productRetailerRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productRetailerRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productRetailerRegistration.ProductId);
            ViewData["RetailerId"] = new SelectList(_context.Set<Retailer>(), "Id", "Id", productRetailerRegistration.RetailerId);
           
            return View(productRetailerRegistration);
        }

        // GET: ProductRetailerRegistrations/Edit/5
        //Returns the  product retailer update form. uses a liq query to select.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRetailerRegistration = (from registration in _context.ProductRetailerRegistration
                                               where registration.Id == id
                                               select registration).FirstOrDefault();
            if (productRetailerRegistration == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", productRetailerRegistration.ProductId);
            ViewData["RetailerId"] = new SelectList(_context.Set<Retailer>(), "Id", "Name", productRetailerRegistration.RetailerId);
            ViewData["DeliveryStatus"] = new SelectList(Enum.GetValues(typeof(DeliveryStatus)), productRetailerRegistration.DeliveryStatus);
            return View(productRetailerRegistration);
        }

        // POST: ProductRetailerRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the registration 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ProductId,RetailerId,DeliveryStatus")] ProductRetailerRegistration productRetailerRegistration)
        {
            if (id != productRetailerRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productRetailerRegistration);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductRetailerRegistrationExists(productRetailerRegistration.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productRetailerRegistration.ProductId);
            ViewData["RetailerId"] = new SelectList(_context.Set<Retailer>(), "Id", "Id", productRetailerRegistration.RetailerId);
            return View(productRetailerRegistration);
        }

        // GET: ProductRetailerRegistrations/Delete/5
        //Returns the registration delete form. uses a lamda query to select the registration to delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRetailerRegistration =  _context.ProductRetailerRegistration
                .Include(p => p.Product)
                .Include(p => p.Retailer)
                .FirstOrDefault(m => m.Id == id);
            if (productRetailerRegistration == null)
            {
                return NotFound();
            }

            return View(productRetailerRegistration);
        }

        // POST: ProductRetailerRegistrations/Delete/5
        //Deletes the registration uses a linq query to select the registration from databse.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productRetailerRegistration = (from registration in _context.ProductRetailerRegistration
                                               where registration.Id == id
                                               select registration).FirstOrDefault();
            _context.ProductRetailerRegistration.Remove(productRetailerRegistration);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the registration using a lamda query.
        private bool ProductRetailerRegistrationExists(int id)
        {
            return _context.ProductRetailerRegistration.Any(e => e.Id == id);
        }
    }
}
