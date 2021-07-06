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
        

        [SetUp]
        public void Init()
        {
            _schoolContext = new SchoolContext(_connection);
            _studentService = new StudentServices(_schoolContext);

            _schoolContext.Students.Add(new Student { ID = 1, LastName="Karakas", FirstMidName="Kaan" });
            ((DbContext)_schoolContext).SaveChanges();
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
            student.LastName.Should().Be("Kaan");
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
        
        [TestCase("2", "İskender","Murat")]
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
        [TestMethod()]
        public void postStudentEditTest()
        {

        }

        [TestMethod()]
        public void postStudentDeleteTest()
        {
            
        }


    }
}