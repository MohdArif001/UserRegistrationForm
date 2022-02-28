using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserRegistrationForm.Models;

namespace UserRegistrationForm.Controllers
{
    public class CustomersController : Controller
    {
        private readonly UserRegistrationDbContext _context;

        public CustomersController(UserRegistrationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var userRegistrationDbContext = _context.Customers.Include(c => c.City).Include(c => c.Country).Include(c => c.State);
            return View(await userRegistrationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.City)
                .Include(c => c.Country)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
           
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName");
            ViewData["CountryName"] = new SelectList(_context.Countries, "CountryName", "CountryName");
            ViewData["StateName"] = new SelectList(_context.States, "StateName", "StateName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,MobileNo,Email,Gender,CountryId,StateId,CityId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", customer.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", customer.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", customer.StateId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", customer.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", customer.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", customer.StateId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,MobileNo,Email,Gender,CountryId,StateId,CityId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", customer.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", customer.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", customer.StateId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.City)
                .Include(c => c.Country)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        public IActionResult GetCountries()
        {
            var countries = _context.Countries.ToList();
            return Json(countries);
        }
       

    }
}
