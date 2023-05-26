using Admin_Portfolio.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Portfolio.Controllers
{
    public class ExpertiseController : Controller
    {
        // GET: ExpertiseController
        public ActionResult Index()
        {

            using var context = new PortfolioContext();
            return View(context.Expertises.ToList());
        }

        // GET: ExpertiseController/Details/5


        // GET: ExpertiseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpertiseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expertise expertise)
        {
            try
            {
                using var context = new PortfolioContext();
                context.Expertises.Add(expertise);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Edit/5
        public ActionResult Edit(int id)
        {

            using var context = new PortfolioContext();
            var expertise = context.Expertises.FirstOrDefault(ex => ex.Id == id);
            return View(expertise);
        }

        // POST: ExpertiseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expertise expertise)
        {
            try
            {
                using var context = new PortfolioContext();
                context.Expertises.Update(expertise);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Delete/5
        public ActionResult Delete(int id)
        {
            using var context = new PortfolioContext();
            var toBeDeleted = context.Expertises.FirstOrDefault(ex => ex.Id == id);
            return View(toBeDeleted);
        }

        // POST: ExpertiseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                using var context = new PortfolioContext();
                var toBeDeleted = context.Expertises.FirstOrDefault(ex => ex.Id == id);
                context.Expertises.Remove(toBeDeleted);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
