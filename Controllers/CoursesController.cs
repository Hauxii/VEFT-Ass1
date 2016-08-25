using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;


namespace WebApplication.Controllers
{
    [Route("/api/courses")]
    public class CoursesController : Controller
    {
        public List<Course> GetCourses(){
            return new List<Course>{
                new Course {
                    Name = "Web Services",
                    TemplateID = "T-514-VEFT",
                    ID = 1,
                    StartDate = new DateTime(2016, 08, 17),
                    EndDate = new DateTime(2016-11-08)
                },
                new Course {
                    Name = "Honnun og smidi",
                    TemplateID = "T-302-HONN",
                    ID = 2,
                    StartDate = new DateTime(2016, 08, 17),
                    EndDate = new DateTime(2016-11-08)
                }
            }; 
        }
    
    }
}