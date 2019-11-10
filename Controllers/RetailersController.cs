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

    //Manages retailers with authorization.
    [Authorize]
    public class RetailersController : Controller
    {
        private readonly Product_Inventory_MVCContext _context;

        public RetailersController(Product_Inventory_MVCContext context)
        {
            _context = context;
        }

        // GET: Retailers
        //Gets all retailers using a linq query.
        public IActionResult Index()
        {
            return View((from retailer in _context.Retailer select retailer).ToList());
        }

        // GET: Retailers/Details/5
        //Gets the details if the retailer using  a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer =  _context.Retailer
                .FirstOrDefault(m => m.Id == id);
            if (retailer == null)
            {
                return NotFound();
            }

            return View(retailer);
        }

        // GET: Retailers/Create
        //Gets the create form .
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds  a retailer to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactNumber")] Retailer retailer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retailer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(retailer);
        }

        // GET: Retailers/Edit/5
        //Returns the retiler update form.Uses a linq query to get the retailer details 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = (from retailers in _context.Retailer
                            where retailers.Id == id
                            select retailers).FirstOrDefault();
            if (retailer == null)
            {
                return NotFound();
            }
            return View(retailer);
        }

        // POST: Retailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the retailer details 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactNumber")] Retailer retailer)
        {
            if (id != retailer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retailer);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetailerExists(retailer.Id))
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
            return View(retailer);
        }

        // GET: Retailers/Delete/5
        //Gets the retailer for delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer =  _context.Retailer
                .FirstOrDefault(m => m.Id == id);
            if (retailer == null)
            {
                return NotFound();
            }

            return View(retailer);
        }

        // POST: Retailers/Delete/5
        //Deletes the retailer from the database .
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var retailer = (from retailers in _context.Retailer
                           where retailers.Id == id
                           select retailers).FirstOrDefault();
            _context.Retailer.Remove(retailer);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks whether the retailer exists.
        private bool RetailerExists(int id)
        {
            return _context.Retailer.Any(e => e.Id == id);
        }
    }
}
