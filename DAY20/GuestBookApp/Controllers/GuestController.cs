using System.Web.Mvc;
using GuestBookApp.Models;
using GuestBookApp.Services;

namespace GuestBookApp.Controllers
{
    public class GuestController : Controller
    {
        private IFeedbackService _feedbackService;

        // Конструктор по умолчанию (создает сервис сам)
        public GuestController()
        {
            _feedbackService = new FeedbackService(new ApplicationDbContext());
        }

        // Конструктор для тестирования (можно использовать позже)
        public GuestController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: Guest/Recent
        public ActionResult Recent()
        {
            var feedbacks = _feedbackService.GetRecentFeedbacks();
            return View(feedbacks);
        }

        // POST: Guest/AddEntry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEntry(FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                _feedbackService.AddFeedback(model);
                TempData["SuccessMessage"] = "Спасибо за отзыв!";
                return RedirectToAction("Recent");
            }

            var feedbacks = _feedbackService.GetRecentFeedbacks();
            return View("Recent", feedbacks);
        }
    }
}