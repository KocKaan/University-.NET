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

            _schoolContext.Students.Add(new Student { ID = 1, LastName="kaan", FirstMidName="Karakas" });
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
            student.LastName.Should().Be("kaan");
            student.Should().NotBeNull();

        }

        [TestMethod()]
        public void postStudentDeleteTest()
        {
            
        }


    }
}