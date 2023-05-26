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
    public class SkillsController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillsController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: Skills
        public ActionResult Index()
        {
            return _context.Skills != null ?
                        View(_context.Skills.ToList()) :
                        Problem("Entity set 'PortfolioContext.Skills'  is null.");
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = _context.Skills
                .FirstOrDefault(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Percent")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = _context.Skills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Percent")] Skill skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.Id))
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
            return View(skill);
        }

        // GET: Skills/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = _context.Skills
                .FirstOrDefault(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Skills == null)
            {
                return Problem("Entity set 'PortfolioContext.Skills'  is null.");
            }
            var skill =  _context.Skills.Find(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
            }

                 _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
            return (_context.Skills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
