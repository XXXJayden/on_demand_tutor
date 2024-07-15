using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
                listFeedback = context.Feedbacks
                    .Include(x => x.Student)
                    .ToList();
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

        public async Task<bool> AddFeedbackAsync(Feedback feedback)
        {
            using var context = new OnDemandTutorDbContext();

            try
            {
                var existingFeedback = await context.Feedbacks
                    .FirstOrDefaultAsync(f => f.BookingId == feedback.BookingId && f.StudentId == feedback.StudentId);

                if (existingFeedback != null)
                {
                    existingFeedback.Rating = feedback.Rating;
                    existingFeedback.Detail = feedback.Detail;
                    context.Feedbacks.Update(existingFeedback);
                }
                else
                {
                    await context.Feedbacks.AddAsync(feedback);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding feedback: {ex.Message}");
                return false;
            }
        }
    }
}
