using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Properties.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {

        static List<Profession> profession = new List<Profession>() {

            new Profession(){Id=1,EmployeeId=1 ,Subject="Java"},
            new Profession(){Id=2,EmployeeId=1 ,Subject="C#"},
            new Profession(){Id=3,EmployeeId=2,Subject="Python"},
            new Profession(){Id=4,EmployeeId=3,Subject="React"}

        };

        // GET: api/<ProfessionController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(profession);
        }

        // GET api/<ProfessionController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Profession p = profession.First(p => p.Id == id);
                return Ok(p);
            }
            catch
            {
                return NotFound("Id is not valid");
            }

        }

        [HttpGet("GetByEmployeeId/{employeeId}")]
        public IActionResult GetByEmployeeId(int employeeId)
        {
            try
            {
                List< Profession> eProfessions=profession.FindAll(p=>p.EmployeeId==employeeId);
                return Ok(eProfessions);
            }
            catch
            {
                return NotFound("no profession of this employee");
            }
        }


        // POST api/<ProfessionController>
        [HttpPost]
        public void Post([FromBody] Profession p)
        {
            p.Id = profession[profession.Count() - 1].Id + 1;
            profession.Add(p);
        }

        // PUT api/<ProfessionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Profession p1)
        {
            Profession p2=profession.FirstOrDefault(p => p.Id == id);
            if (p2!=null)
            {
                p2.Id=p1.Id;
                p2.EmployeeId=p1.EmployeeId;
                p2.Subject=p1.Subject;
            }

        }

        // DELETE api/<ProfessionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int i=profession.FindIndex(p => p.Id==id);
            if (i != -1)
                profession.RemoveAt(i);
        }
    }
}
