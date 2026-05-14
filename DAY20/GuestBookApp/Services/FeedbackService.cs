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

        public List<GuestEntry> GetRecentFeedbacks(int count = 20)
        {
            return _db.GuestEntries
                .OrderByDescending(x => x.Date)
                .Take(count)
                .ToList();
        }

        public void AddFeedback(FeedbackViewModel model)
        {
            var entry = new GuestEntry
            {
                Name = model.Name,
                Message = model.Message,
                Rating = model.Rating,
                Date = DateTime.Now
            };

            _db.GuestEntries.Add(entry);
            _db.SaveChanges();
        }
    }
}