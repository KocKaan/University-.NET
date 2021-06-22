using Autofac;
using Autofac.Integration.Mvc;
using KarakasUniversity.DAL;
using KarakasUniversity.Models.Interfaces;
using KarakasUniversity.Services;
using KarakasUniversity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarakasUniversity
{
    public static class IocConfig
    {
        public static ContainerBuilder Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SchoolContext>().As<ISchoolContext>();
            builder.RegisterType<StudentServices>().As<IStudentService>();
            builder.RegisterType<HomeService>().As<IHomeService>();

            return builder;
        }
    }
}