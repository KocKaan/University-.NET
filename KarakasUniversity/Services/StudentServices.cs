
namespace KarakasUniversity.Services
{
    using KarakasUniversity.Models;
    using KarakasUniversity.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class StudentServices
    {
        private readonly ISchoolContext _dataContext;


        public StudentServices(ISchoolContext schoolContext)
        {
            _dataContext= schoolContext;
        }


        public Student getStudentDetails(int? id)
        {
//if (id == null)
  //          {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //      }
            Student student = _dataContext.Students.Find(id);
            //    if (student == null)
            //  {
            //    return HttpNotFound();
            //   }
            return student;
        }





    }


}