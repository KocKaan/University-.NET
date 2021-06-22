using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarakasUniversity.DAL;
using KarakasUniversity.Services;
using KarakasUniversity.Services.Interfaces;
using KarakasUniversity.ViewModels;

namespace KarakasUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;



        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
            public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {

            List<EnrollmentDateGroup> dataList = _homeService.getStudentEnrollments();
            return View(dataList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _homeService.dispose();
            base.Dispose(disposing);
        }
    }
}