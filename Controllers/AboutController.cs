global using Admin_Portfolio.Data.DBContexts;
using Admin_Portfolio.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Admin_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutController
        public ActionResult Index()
        {
            using var context = new PortfolioContext();
            return View(new List<About> { context.Abouts.First() });
        }

        public ActionResult Edit(int id)
        {
            using var context = new PortfolioContext();
            var toBeEdited = context.Abouts.FirstOrDefault
            (a => a.Id == id);
            return View(toBeEdited);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(About about)
        {
            using var context = new PortfolioContext();

            context.Abouts.Update(about);

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

        // GET: AboutController/Delete/5
    }
}
