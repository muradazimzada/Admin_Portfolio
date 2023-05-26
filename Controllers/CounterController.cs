using Admin_Portfolio.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Admin_Portfolio.Controllers
{
    public class CounterController : Controller
    {
        // GET: CounterController
        public ActionResult Index()
        {
            using var context = new PortfolioContext();

            var list = context.Counters.ToList();

            return View(list);
        }

        // GET: CounterController/Details/5
     

        // GET: CounterController/Create
        public ActionResult Create()
        {
         

            return View();
        }

        // POST: CounterController/Create
        [HttpPost]
        public ActionResult Create( Counter counter)
        {
            using var context = new PortfolioContext();

            context.Counters.Add(counter);

            context.SaveChanges();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CounterController/Edit/5
        public ActionResult Edit(int id)
        {
            using var context = new PortfolioContext();

            var counter = context.Counters.FirstOrDefault(counter=> counter.Id == id);

            return View(counter);
        }

        // POST: CounterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Counter counter)
        {
            using var context = new PortfolioContext();

            context.Update(counter);
            context.SaveChanges();

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CounterController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: CounterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {


            using var context = new PortfolioContext();
            var toBeDeleted = context.Counters.FirstOrDefault(counter => counter.Id == id);
            context.Counters.Remove(toBeDeleted);
            context.SaveChanges();

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
