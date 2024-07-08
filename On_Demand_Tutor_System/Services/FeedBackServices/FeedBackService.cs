using BusinessObjects.Models;
using DataAccessLayer;
using Repositories.FeedBackRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FeedBackServices
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedbackRepository;

        public FeedBackService()
        {
            _feedbackRepository = new FeedBackRepository();
        }
        public List<Feedback> GetAllFeedback()
        {
            return _feedbackRepository.GetAllFeedback();
        }
        public void SaveFeedback(Feedback feedback)
        {
            _feedbackRepository.SaveFeedback(feedback);
        }
        public void UpdateFeedback(Feedback feedback)
        {
            _feedbackRepository.UpdateFeedback(feedback);
        }
        public void DeleteFeedback(short feedbackId)
        {
            _feedbackRepository.DeleteFeedback(feedbackId);
        }
        public Feedback GetFeedbackById(short feedbackId)
        {
            return _feedbackRepository.GetFeedbackById(feedbackId);
        }
        public async Task<bool> AddFeedbackAsync(Feedback feedback)
        {
            return await _feedbackRepository.AddFeedbackAsync(feedback);
        }

    }
}
