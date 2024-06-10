using BusinessObjects.Models;
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
    }
}
