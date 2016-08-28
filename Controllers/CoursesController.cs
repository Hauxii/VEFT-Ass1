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
                        EndDate = new DateTime(2016-11-08),
                        students = new List<Student> {
                            new Student {
                                SSN = "031191-1234",
                                Name = "Haukur Ingi"
                            },
                            new Student {
                                SSN = "131190-1234",
                                Name = "Vilhjalmur Alex"
                            }
                        }
                    },
                    new Course {
                        Name = "Honnun og smidi",
                        TemplateID = "T-302-HONN",
                        ID = 2,
                        StartDate = new DateTime(2016, 08, 17),
                        EndDate = new DateTime(2016-11-08),
                        students = new List<Student> {
                            new Student {
                                SSN = "031191-1234",
                                Name = "Haukur Ingi"
                            },
                            new Student {
                                SSN = "131190-1234",
                                Name = "Vilhjalmur Alex"
                            }
                        }
                    }
                };
            }
        }
        //validating course input to some extent
        private bool isNewCourseValid(Course course)
        {
            if(allCourses.FindIndex(item => item.ID == course.ID) != -1){
                return false;
            }
            if(course.Name == null || course.Name == ""){
                return false;
            }
            if(course.TemplateID == null || course.TemplateID == ""){
                return false;
            }
            if(course.StartDate == null || course.EndDate == null){
                return false;
            }
            return true;
        }
        //validating student input to some extent
        private bool isNewStudentValid(Student student)
        {
            if(student.Name == null || student.Name == ""){
                return false;
            }
            if(student.SSN == null || student.SSN == ""){
                return false;
            }
            return true;
        }

        public IActionResult GetCourses()
        {
            return Ok(allCourses);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCourseByID")]
        public IActionResult GetCourseByID(int id)
        {
            Course toFind = allCourses.Find(item => item.ID == id);

            if(toFind == null){
                return NotFound();
            }
            return Ok(toFind);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody]Course newCourse)
        {            
            if(!isNewCourseValid(newCourse)){
                return BadRequest();
            }
            allCourses.Add(newCourse);
            var location = Url.Link("GetCourseByID", new { id = newCourse.ID});
            return Created(location, newCourse);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditCourse(int id, [FromBody]Course edited)
        {
            int toEdit = allCourses.FindIndex(item => item.ID == edited.ID);
            if(id != allCourses[toEdit].ID){
                return BadRequest("Cannot change ID");
            }

            if(!isNewCourseValid(edited)){
                return BadRequest();
            }

            if(toEdit == -1){
                return BadRequest();
            }

            allCourses[toEdit] = edited;
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
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}/students", Name = "GetStudents")]
        public IActionResult GetStudents(int id){
            int index = allCourses.FindIndex(item => item.ID == id);
            if(index == -1){
                return NotFound();
            }
            return Ok(allCourses[index].students);
        }

        [HttpPost]
        [Route("{id:int}/students", Name = "AddStudents")]
        public IActionResult AddStudent(int id, [FromBody]Student newStudent)
        {
            int index = allCourses.FindIndex(item => item.ID == id);
            if(index == -1){
                return NotFound();
            }

            if(!isNewStudentValid(newStudent)){
                return BadRequest();
            }

            allCourses[index].students.Add(newStudent);
            return Created("GetStudents", newStudent);
        }
    }
}

