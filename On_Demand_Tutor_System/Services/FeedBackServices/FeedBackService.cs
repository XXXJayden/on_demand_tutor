using BusinessObjects.Models;
using DataAccessLayer;
using Repositories.BookingRepository;
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

        public (double OneStar, double TwoStar, double ThreeStar, double FourStar, double FiveStar) GetRatingPercentages()
        {
            try
            {
                var feedback = _feedbackRepository.GetAllFeedback();
                int totalRating = feedback.Count(b => b.Rating > 0);

                if (totalRating == 0)
                {
                    return (0, 0, 0, 0, 0);
                }

                double CalculatePercentage(int rating) =>
                    Math.Round((double)feedback.Count(b => b.Rating == rating) / totalRating * 100, 2);

                return (
                    OneStar: CalculatePercentage(1),
                    TwoStar: CalculatePercentage(2),
                    ThreeStar: CalculatePercentage(3),
                    FourStar: CalculatePercentage(4),
                    FiveStar: CalculatePercentage(5)
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
