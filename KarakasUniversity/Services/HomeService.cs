using KarakasUniversity.Models.Interfaces;
using KarakasUniversity.Services.Interfaces;
using KarakasUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarakasUniversity.Services
{
    public class HomeService: IHomeService
    {

        private readonly ISchoolContext _schoolContext;

       public HomeService(ISchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public List<EnrollmentDateGroup> getStudentEnrollments()
        {
            //The LINQ statement groups the student entities by enrollment date, calculates the number of
            //entities in each group, and stores the results in a collection of EnrollmentDateGroup view model objects.

            IQueryable<EnrollmentDateGroup> data = from student in _schoolContext.Students
                                                   group student by student.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       StudentCount = dateGroup.Count()
                                                   };
            return data.ToList();

        }

        public void dispose()
        {
            _schoolContext.Dispose();
        }
    }
    
}