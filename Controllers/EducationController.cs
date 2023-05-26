using Admin_Portfolio.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Portfolio.Controllers
{
    public class EducationController : Controller
    {
        // GET: EducationController
        public ActionResult Index()
        {

            using var context = new PortfolioContext();
            var list = context.Educations.ToList();
            return View(list);
        }

        // GET: EducationController/Details/5


        // GET: EducationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Education education)
        {
            using var context = new PortfolioContext();
            context.Educations.Add(education);
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

        // GET: EducationController/Edit/5
        public ActionResult Edit(int id)
        {
            using var context = new PortfolioContext();
            var toBeEdited = context.Educations.FirstOrDefault(ed => ed.Id == id);
            return View(toBeEdited);
        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Education education)
        {
            using var context = new PortfolioContext();

            context.Update(education);

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

        // GET: EducationController/Delete/5
        public ActionResult Delete(int id)
        {
            using var context = new PortfolioContext();
            var toBeDeleted = context.Educations.FirstOrDefault(ed => ed.Id == id);
            return View(toBeDeleted);
        }

        // POST: EducationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            using var context = new PortfolioContext();
            var toBeDeleted = context.Educations.FirstOrDefault(ed => ed.Id == id);
            context.Educations.Remove(toBeDeleted);
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
