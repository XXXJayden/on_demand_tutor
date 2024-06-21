using BusinessObjects.Models;

namespace DataAccessLayer
{
    public class StudentDAO
    {
        public static List<Student> GetAllStudent()
        {
            var listStudent = new List<Student>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listStudent = context.Students.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listStudent;
        }


        public static Student GetStudentByEmail(string studentEmail)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Students.FirstOrDefault(c => c.Email.Equals(studentEmail));
        }

        public static void SaveStudent(Student student)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Students.Add(student);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateStudent(Student student)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Student>(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Student GetStudentById(int studentId)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Students.FirstOrDefault(c => c.StudentId.Equals(studentId));
        }

        public static void DeleteStudent(int studentId)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var student = context.Students.FirstOrDefault(c => c.StudentId == studentId);
                if (student != null)
                {
                    context.Students.Remove(student);
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