
namespace KarakasUniversity.Models.Interfaces
{
    using KarakasUniversity.Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ISchoolContext
    {
         DbSet<Student> Students { get; set; }
         DbSet<Enrollment> Enrollments { get; set; }
         DbSet<Course> Courses { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(Object entity);
        void Dispose();
    }

    
}
