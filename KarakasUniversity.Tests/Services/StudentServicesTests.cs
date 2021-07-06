using Microsoft.VisualStudio.TestTools.UnitTesting;
using KarakasUniversity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using KarakasUniversity.Models.Interfaces;
using KarakasUniversity.Services.Interfaces;
using KarakasUniversity.Model.Entities;
using Moq;
using KarakasUniversity.Services.DTO;
using Effort.Provider;
using System.Data.Entity;
using FluentAssertions;

namespace KarakasUniversity.Services.Tests
{
    [TestFixture]
    public class StudentServicesTests
    {
        EffortConnection _connection = Effort.DbConnectionFactory.CreateTransient();
        private IStudentService _studentService;
        private ISchoolContext _schoolContext;
        

        [OneTimeSetUp]
        public void Init()
        {
            _schoolContext = new SchoolContext(_connection);
            _studentService = new StudentServices(_schoolContext);

            _schoolContext.Students.Add(new Student { ID = 1, LastName="Karakas", FirstMidName="Kaan" });
            _schoolContext.Students.Add(new Student { ID = 2, LastName = "Kebap", FirstMidName = "Adana" });
           ((DbContext)_schoolContext).SaveChanges();

            //takes snapshot so after each method the database goes back to original
            _connection.CreateRestorePoint();
        }
        [TearDown]
        public void ClearUp()
        {
            _connection.RollbackToRestorePoint(_schoolContext as DbContext);
        }

        [TestCase("","")]
        public void getStudentIndex(string sortOrder, string searchString)
        {
            //Act 
            var students = _studentService.getStudentIndex(sortOrder, searchString);

            //Assert
            students.Count.Should().Be(2);
        }

        [TestCase("1")]
        public void getStudentTest(int? id )
        {
            //EFFORT DATABASE lazım
            //Arrange 

            //   _schoolContext.Setup(x => x.getStudent(id)).Returns(StudentViewModel);
            //Act
         
          var student = _studentService.getStudent(id);
            //Assert
            //    student.Should().Be(studentViewModel);
            student.ID.Should().Be(id);
            student.LastName.Should().Be("Karakas");
            student.Should().NotBeNull();

        }
        [TestCase("1")]
        public void getStudentEditTest(int? id)
        {
            //Act
            var student = _studentService.getStudentEdit(id);

            //Assert
            student.Should().NotBeNull();
            student.ID.Should().Be(id);
            
        }
        
        [TestCase("3", "İskender","Murat")]
        public void postStudentCreateTest(int id, string name, string surname)
        {
            //Arrange
            var model = new StudentRequestModel();
            model.ID = id;
            model.FirstMidName = name;
            model.LastName = surname;
            
            //Act
            _studentService.postStudentCreate(model);
            //Assert
            _schoolContext.Students.Count(p => p.LastName == model.LastName).Should().NotBe(0);
        }
        [TestCase("2","Kerem", "Korsan","05/02/2021")]
        public void postStudentEditTest(int id, string firstName, string lastName,string dateTime)
        {
            //Act
            DateTime enrollmentDate = DateTime.Parse(dateTime);
            _studentService.postStudentEdit(id, firstName, lastName,enrollmentDate );

            //Assert
            var student = _schoolContext.Students.FirstOrDefault(x => x.ID == id);
            student.Should().NotBeNull();
            student.FirstMidName.Should().Be(firstName);
            student.LastName.Should().Be(lastName);
        }

        [TestCase("1")]
        public void postStudentDeleteTest(int id)
        {
            //Act 
            _studentService.postStudentDelete(id);
            //Assert
            _schoolContext.Students.Count(p => p.ID == id).Should().Be(0);
        }

       


    }
}