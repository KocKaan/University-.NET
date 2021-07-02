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

namespace KarakasUniversity.Services.Tests
{
    [TestFixture]
    public class StudentServicesTests
    {
        private IStudentService _studentService;
        private Mock<ISchoolContext> _schoolContext;
      
        [SetUp]
        public void Init()
        {
            _schoolContext = new Mock<ISchoolContext>();
            _studentService = new StudentServices(_schoolContext.Object);
        }

        [TestMethod()]
        public void postStudentDeleteTest()
        {
            Assert.Fail();
        }
    }
}