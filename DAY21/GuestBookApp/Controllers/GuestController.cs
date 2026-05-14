using System.Web.Mvc;
using GuestBookApp.Models;
using GuestBookApp.Services;

namespace GuestBookApp.Controllers
{
    public class GuestController : Controller
    {
        private IFeedbackService _feedbackService;

        public GuestController()
        {
            _feedbackService = new FeedbackService(new ApplicationDbContext());
        }

        // GET: Guest/Recent - список отзывов
        public ActionResult Recent()
        {
            var feedbacks = _feedbackService.GetRecentFeedbacks();
            return View(feedbacks);
        }

        // GET: Guest/Index - полный список (для админа)
        public ActionResult Index()
        {
            var feedbacks = _feedbackService.GetAllFeedbacks();
            return View(feedbacks);
        }

        // POST: Guest/AddEntry - добавить отзыв
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

        // GET: Guest/Edit/5 - форма редактирования
        public ActionResult Edit(int id)
        {
            var feedback = _feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }

            var model = new FeedbackViewModel
            {
                UserName = feedback.UserName,
                Message = feedback.Message,
                Rating = feedback.Rating
            };

            return View(model);
        }

        // POST: Guest/Edit/5 - сохранить изменения
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                _feedbackService.UpdateFeedback(id, model);
                TempData["SuccessMessage"] = "Отзыв успешно обновлен!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // POST: Guest/Delete/5 - удалить отзыв
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _feedbackService.DeleteFeedback(id);
            TempData["SuccessMessage"] = "Отзыв успешно удален!";
            return RedirectToAction("Index");
        }
    }
}