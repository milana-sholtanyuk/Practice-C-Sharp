using System;
using System.Linq;
using System.Web.Mvc;
using GuestBookApp.Models;

namespace GuestBookApp.Controllers
{
    public class GuestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Guest/Recent
        public ActionResult Recent()
        {
            // Получаем последние 20 отзывов, отсортированных по дате (сначала новые)
            var recentEntries = db.GuestEntries
                .OrderByDescending(x => x.Date)
                .Take(20)
                .ToList();

            return View(recentEntries);
        }

        // POST: Guest/AddEntry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEntry(GuestEntry entry)
        {
            if (ModelState.IsValid)
            {
                entry.Date = DateTime.Now;
                db.GuestEntries.Add(entry);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Спасибо! Ваш отзыв успешно добавлен.";
                return RedirectToAction("Recent");
            }

            // Если есть ошибки валидации, возвращаем на страницу с отзывами
            var recentEntries = db.GuestEntries
                .OrderByDescending(x => x.Date)
                .Take(20)
                .ToList();

            return View("Recent", recentEntries);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}