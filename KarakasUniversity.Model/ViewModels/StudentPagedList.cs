using KarakasUniversity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarakasUniversity.ViewModels
{
    public class StudentPagedList
    {
        public IEnumerable<Student> Student { get; set; }

        public string SortOrder { get; set; }

        public string CurrentFilter { get; set; }

        public string SearchString { get; set; }

        public int? Page { get; set; }

    }
}