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
        public IActionResult CreateCourse([FromBody]Course newCourse)
        {            
            if(newCourse == null){
                return BadRequest();
            }
            allCourses.Add(newCourse);
            var location = Url.Link("GetCourseByID", new { id = newCourse.ID});
            return Created(location, newCourse);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditCourse([FromBody]Course edited)
        {
            //TODO: nota id úr urli / eða passa uppa að ekki sé hægt að breyta id
            if(edited == null){
                return BadRequest();
            }
            int toEdit = allCourses.FindIndex(item => item.ID == edited.ID);
            if(toEdit == -1){
                return BadRequest();
            }
            //TODO: validate input?
            allCourses[toEdit] = edited;
            //allCourses.ForEach(item => Console.WriteLine(item.Name));
            return Ok(edited);
        }
    
        [HttpDelete]
        public IActionResult DeleteCourse(int idToDelete)
        {
            int index = allCourses.FindIndex(item => item.ID == idToDelete);
            if(index == -1){
                return BadRequest();
            }
            allCourses.RemoveAt(index);
            //allCourses.ForEach(item => Console.WriteLine(item.Name));
            return NoContent();
        }
    }
}