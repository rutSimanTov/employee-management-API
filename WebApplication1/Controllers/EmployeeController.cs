using Microsoft.AspNetCore.Mvc;
using WebApplication1.Properties.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> Employees = new List<Employee>() {

            new Employee(){Id=1,Name="gila" ,Age=25, Experience=5},
            new Employee(){Id=2,Name="hila" ,Age=35, Experience=10},
            new Employee(){Id=3,Name="chana",Age=27, Experience=7},
            new Employee(){Id=4,Name="dina",Age=40,Experience=20}

        }
            ;




        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Employees);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Employee e = Employees.First(e => e.Id == id);
                return Ok(e);
            }
            catch {
                return NotFound("Id is not valid");
            }

        }

        [HttpGet("GetByExperience/{experience}")]
        public IActionResult GetByExperience(int experience)
        {
            try
            {
                List<Employee> goodE = Employees.FindAll(e => e.Experience == experience);
                return Ok(goodE);
            }
            catch
            {
                return NotFound("no employee with this experience");
            }

        }


        //// GET api/<employeeController>/find
        //[HttpGet("find")]
        //public List<employee> FindEm(string query)
        //{
        //    return query;
        //}

        
        [HttpPost]
        public void Post([FromBody] Employee e)
        {
            e.Id = Employees[Employees.Count-1].Id+1;
            Employees.Add(e);
        }

        [HttpPost("createDataSave/{path}")]
        public IActionResult post(string path)
        {
            if (!path.Contains(".txt"))
                return BadRequest("you shoiuld provide a txt file");
            try
            {
                using (StreamWriter write = new StreamWriter(path))
                {
                    foreach (Employee e in Employees)
                    {
                        write.WriteLine();
                        write.Write("Employee" + e.Id);
                        write.Write(", name: " + e.Name);
                        write.Write(", age: " + e.Age);
                        write.Write(", experience: " + e.Experience);
                    }
                    return Ok("success");
                }

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee e)
        {
           int Index=Employees.FindIndex(e=>e.Id==id);
            Employees[Index].Id = e.Id;
            Employees[Index].Name = e.Name;
            Employees[Index].Age = e.Age;
            Employees[Index].Experience = e.Experience;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           Employee e= Employees.FirstOrDefault(e => e.Id == id);
           Employees.Remove(e);
        }
    }
}
