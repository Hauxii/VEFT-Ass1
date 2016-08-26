using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("/api/courses/{id:int}/students")]
    public class StudentsController : Controller
    {
        public List<Student> allStudents;

        public StudentsController()
        {
            if(allStudents == null){
                allStudents = new List<Student> {
                    new Student {
                        SSN = "031191-1234",
                        Name = "Haukur Ingi"
                    },
                    new Student {
                        SSN = "131190-1234",
                        Name = "Vilhjalmur Alex"
                    }
                };
            }
            
        }
        [HttpGet]
        [Route("", Name = "GetStudents")]
        public List<Student> GetStudents(){
            return allStudents;
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody]Student newStudent)
        {
            if(newStudent == null){
                return BadRequest();
            }
            allStudents.Add(newStudent);
            return Created("GetStudents", newStudent);
        }

    }
}