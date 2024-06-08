using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Threading.Tasks;

namespace Repositories.FeedBackRepositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        public List<Feedback> GetAllFeedback() => FeedBackDAO.GetAllFeedback();
        public void SaveFeedback(Feedback feedback) => FeedBackDAO.SaveFeedback(feedback);
        public void UpdateFeedback(Feedback feedback) => FeedBackDAO.UpdateFeedback(feedback);
        public void DeleteFeedback(short feedbackId) => FeedBackDAO.DeleteFeedback(feedbackId);
        public Feedback GetFeedbackById(short feedbackId) => FeedBackDAO.GetFeedbackById(feedbackId);
    }
}
