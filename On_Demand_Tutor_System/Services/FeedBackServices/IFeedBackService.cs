using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FeedBackServices
{
    public interface IFeedBackService
    {
        List<Feedback> GetAllFeedback();
        void SaveFeedback(Feedback feedback);
        void UpdateFeedback(Feedback feedback);
        void DeleteFeedback(short feedbackId);
        Achievement GetFeedbackById(short feedbackId);
    }
}
