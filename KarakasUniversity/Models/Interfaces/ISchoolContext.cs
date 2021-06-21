
namespace KarakasUniversity.Models.Interfaces
{
    using System.Data.Entity;
    public interface ISchoolContext
    {
         DbSet<Student> Students { get; set; }
         DbSet<Enrollment> Enrollments { get; set; }
         DbSet<Course> Courses { get; set; }

        int SaveChanges();
    }

    
}
