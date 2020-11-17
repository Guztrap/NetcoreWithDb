using connectoToPostgres.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using connectoToPostgres.Entities;

namespace connectoToPostgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentFacade studentFacade;

        public StudentController(IStudentFacade facade)
        {
            studentFacade = facade ?? throw new ArgumentNullException(nameof(facade));
        }

        [Route("/student/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await studentFacade.GetStudentById(id);
            return Ok(response);
        }

        [Route("/students")]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var response = await studentFacade.GetStudents();
            return Ok(response);
        }

        [Route("/")]
        [HttpPost]
        public async Task<IActionResult> SaveStudent([FromBody] Student student)
        {
            var response = await studentFacade.SaveStudent(student);
            return Ok(response);
        }
    }
}
