﻿
namespace KarakasUniversity.Services
{
    using Deneme;
    using KarakasUniversity.Models;
    using KarakasUniversity.Models.Interfaces;
    using KarakasUniversity.Services.Interfaces;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    

    public class StudentServices : IStudentService
    {
        private readonly ISchoolContext _schoolContext;


        public StudentServices(ISchoolContext schoolContext)
        {
            _schoolContext= schoolContext;
        }




        public List<Student> getStudentIndex(string sortOrder, string searchString)
        {
            //bak asquaeryble farka bak öncekiyle
            var students = _schoolContext.Students.AsQueryable();
                           
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
      

            return students.ToList();
        }

        public Student getStudent(int? id)
        {
//if (id == null)
  //          {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //      }
            Student student = _schoolContext.Students.Find(id);
            //    if (student == null)
            //  {
            //    return HttpNotFound();
            //   }
            return student;
        }

        public void postStudentCreate(Student student) 
        {
            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();

          //deleted the save changes method
        }
        public Student getStudentEdit(int? id)
        {
          Student student=_schoolContext.Students.Find(id);

            return student;

        }
        
        public void postStudentEdit(Student std)
        {
            _schoolContext.Entry(std).State = EntityState.Modified;
            _schoolContext.SaveChanges();

         //  return RedirectToAction("Index");

        }

        public void postStudentDelete(int id)
        {
            //değiştir
            Student student = _schoolContext.Students.Find(id);
            _schoolContext.Students.Remove(student);
            _schoolContext.SaveChanges();
            Class1 cla = new Class1();
            int kk = cla.ten();

        }

        public void dispose()
        {
            _schoolContext.Dispose();
        }


    }


}