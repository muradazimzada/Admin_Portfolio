using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin_Portfolio.Data.Models;
using Admin_Portfolio.Data.DBContexts;

namespace Admin_Portfolio.Controllers
{
    public class MyservicesController : Controller
    {
        private readonly PortfolioContext _context;

        public MyservicesController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: Myservices
        public async Task<IActionResult> Index()
        {
              return _context.Myservices != null ? 
                          View(await _context.Myservices.ToListAsync()) :
                          Problem("Entity set 'PortfolioContext.Myservices'  is null.");
        }

        // GET: Myservices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Myservices == null)
            {
                return NotFound();
            }

            var myservice = await _context.Myservices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myservice == null)
            {
                return NotFound();
            }

            return View(myservice);
        }

        // GET: Myservices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Myservices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,Subtitle,Icon")] Myservice myservice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myservice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myservice);
        }

        // GET: Myservices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Myservices == null)
            {
                return NotFound();
            }

            var myservice = await _context.Myservices.FindAsync(id);
            if (myservice == null)
            {
                return NotFound();
            }
            return View(myservice);
        }

        // POST: Myservices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,Subtitle,Icon")] Myservice myservice)
        {
            if (id != myservice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myservice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyserviceExists(myservice.Id))
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
            return View(myservice);
        }

        // GET: Myservices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Myservices == null)
            {
                return NotFound();
            }

            var myservice = await _context.Myservices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myservice == null)
            {
                return NotFound();
            }

            return View(myservice);
        }

        // POST: Myservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Myservices == null)
            {
                return Problem("Entity set 'PortfolioContext.Myservices'  is null.");
            }
            var myservice = await _context.Myservices.FindAsync(id);
            if (myservice != null)
            {
                _context.Myservices.Remove(myservice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyserviceExists(int id)
        {
          return (_context.Myservices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
