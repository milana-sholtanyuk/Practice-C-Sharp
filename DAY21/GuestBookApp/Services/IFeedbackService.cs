using System.Collections.Generic;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public interface IFeedbackService
    {
        List<Feedback> GetAllFeedbacks();
        List<Feedback> GetRecentFeedbacks(int count = 20);
        Feedback GetFeedbackById(int id);
        void AddFeedback(FeedbackViewModel model);
        void UpdateFeedback(int id, FeedbackViewModel model);
        void DeleteFeedback(int id);
        int GetAverageRating();
    }
}