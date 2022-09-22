using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using VidCourse.Models;
namespace VidCourse.ViewModels
{
    public class RandomViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customer { get; set; }

    }
}