using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("/api/courses")]
    public class CoursesController : Controller
    {
        public List<Course> allCourses;
        public CoursesController(){
            if(allCourses == null){
                allCourses = new List<Course>{
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

        public List<Course> GetCourses()
        {
            return allCourses;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCourseByID")]
        public IActionResult GetCourseByID(int id)
        {
            Course toFind = allCourses.Find(item => item.ID == id);

            if(toFind == null){
                return StatusCode(404);
            }
            return Ok(toFind);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody]dynamic newCourse)
        {
            /*
            Course newCourse = new Course {
                ID = data.id,
                TemplateID = data.templateid,
                Name = data.name,
                StartDate = data.startdate,
                EndDate = data.enddate
            };
            */
            
            return newCourse;
            /*
            allCourses.Add(newCourse);
            var location = Url.Link("GetCourseByID", new { id = newCourse.ID});
            return Created(location, newCourse);
            */
        }
    
    }
}