using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.FeedBackRepositories
{
    public interface IFeedBackRepository
    {
        List<Feedback> GetAllFeedback();
        void SaveFeedback(Feedback feedback);
        void UpdateFeedback(Feedback feedback);
        void DeleteFeedback(short feedbackId);
        Feedback GetFeedbackById(short feedbackId);
        Task<bool> AddFeedbackAsync(Feedback feedback);
        Task<IList<Feedback>> GetFeedBackByBookingId(int bookingId);
    }
}
