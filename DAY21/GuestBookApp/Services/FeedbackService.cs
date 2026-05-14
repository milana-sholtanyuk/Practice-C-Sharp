using System;
using System.Linq;
using System.Collections.Generic;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _db;

        public FeedbackService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return _db.Feedbacks.OrderByDescending(x => x.SubmittedAt).ToList();
        }

        public List<Feedback> GetRecentFeedbacks(int count = 20)
        {
            return _db.Feedbacks
                .OrderByDescending(x => x.SubmittedAt)
                .Take(count)
                .ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _db.Feedbacks.Find(id);
        }

        public void AddFeedback(FeedbackViewModel model)
        {
            var feedback = new Feedback
            {
                UserName = model.UserName,
                Message = model.Message,
                Rating = model.Rating,
                SubmittedAt = DateTime.Now
            };

            _db.Feedbacks.Add(feedback);
            _db.SaveChanges();
        }

        public void UpdateFeedback(int id, FeedbackViewModel model)
        {
            var feedback = _db.Feedbacks.Find(id);
            if (feedback != null)
            {
                feedback.UserName = model.UserName;
                feedback.Message = model.Message;
                feedback.Rating = model.Rating;
                _db.SaveChanges();
            }
        }

        public void DeleteFeedback(int id)
        {
            var feedback = _db.Feedbacks.Find(id);
            if (feedback != null)
            {
                _db.Feedbacks.Remove(feedback);
                _db.SaveChanges();
            }
        }

        public int GetAverageRating()
        {
            if (!_db.Feedbacks.Any())
                return 0;

            return (int)Math.Round(_db.Feedbacks.Average(x => x.Rating));
        }
    }
}