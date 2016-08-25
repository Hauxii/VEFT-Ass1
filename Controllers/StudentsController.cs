using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("/api/students")]
    public class StudentsController : Controller
    {
        public List<Student> GetStudents(){
            return new List<Student>{
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
}