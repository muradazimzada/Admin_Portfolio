using Admin_Portfolio.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: ExperienceController
        public ActionResult Index()
        {

            using var context = new PortfolioContext();

            var list = context.Experiences.ToList();
            return View(list);
        }


        // GET: ExperienceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperienceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Experience experience)
        {

            try
            {
                var context = new PortfolioContext();
                context.Experiences.Add(experience);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperienceController/Edit/5
        public ActionResult Edit(int id)
        {

            using var context = new PortfolioContext();
            var experience = context.Experiences.FirstOrDefault(ex => ex.Id == id);
            return View(experience);
        }

        // POST: ExperienceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Experience experience)
        {
            try
            {
                using var context = new PortfolioContext();
                context.Experiences.Update(experience);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperienceController/Delete/5
        public ActionResult Delete(int id)
        {

            using var context = new PortfolioContext();
            var experience = context.Experiences.FirstOrDefault(experience=> experience.Id == id);
            return View(experience);
        }

        // POST: ExperienceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                using var context = new PortfolioContext();
                var toBeDeleted = context.Experiences.FirstOrDefault(exp=> exp.Id == id);
                context.Experiences.Remove(toBeDeleted);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
