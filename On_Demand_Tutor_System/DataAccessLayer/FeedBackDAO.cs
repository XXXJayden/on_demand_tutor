using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FeedBackDAO
    {
        public static List<Feedback> GetAllFeedback()
        {
            var listFeedback = new List<Feedback>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listFeedback = context.Feedbacks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listFeedback;
        }
        public static void SaveFeedback(Feedback feedback)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Feedbacks.Add(feedback);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateFeedback(Feedback feedback)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Feedback>(feedback).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Feedback GetFeedbackById(int feedbackId)
        {
            using var db = new OnDemandTutorDbContext();
            return
                db.Feedbacks.FirstOrDefault(c => c.FbId.Equals(feedbackId));
        }
        public static void DeleteFeedback(short feedbackId)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var feedback = context.Feedbacks.FirstOrDefault(c => c.FbId == feedbackId);
                if (feedback != null)
                {
                    context.Feedbacks.Remove(feedback);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
