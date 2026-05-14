using System.Collections.Generic;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public interface IFeedbackService
    {
        List<GuestEntry> GetRecentFeedbacks(int count = 20);
        void AddFeedback(FeedbackViewModel model);
    }
}