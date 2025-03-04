using Microsoft.AspNetCore.Mvc;
using WebApplication1.Properties.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        static List<Employer> Employers=new List<Employer>() { 
        
            new Employer(){Id=1,Name="gila" ,Age=25, Experiance=5},
            new Employer(){Id=2,Name="hila" ,Age=35, Experiance=10},
            new Employer(){Id=3,Name="chana",Age=27, Experiance=7},
            new Employer(){Id=4,Name="dina",Age=40,Experiance=20}

        }
            ;  



       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Employers);
        }

       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Employer e = Employers.First(e => e.Id == id);
                return Ok(e);
            }
            catch {
                return NotFound("Id is not valid");
            }
          
        }

        //// GET api/<EmployerController>/find
        //[HttpGet("find")]
        //public List<Employer> FindEm(string query)
        //{
        //    return query;
        //}

        
        [HttpPost]
        public void Post([FromBody] Employer e)
        {
            e.Id = Employers[Employers.Count-1].Id+1;
            Employers.Add(e);
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
                    foreach (Employer e in Employers)
                    {
                        write.WriteLine();
                        write.Write("employer" + e.Id);
                        write.Write(", name: " + e.Name);
                        write.Write(", age: " + e.Age);
                        write.Write(", experiance: " + e.Experiance);
                    }
                    return Ok("success");
                }

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/<EmployerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employer e)
        {
           int Index=Employers.FindIndex(e=>e.Id==id);
            Employers[Index].Id = e.Id;
            Employers[Index].Name = e.Name;
            Employers[Index].Age = e.Age;
            Employers[Index].Experiance = e.Experiance;
        }

        // DELETE api/<EmployerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           Employer e= Employers.FirstOrDefault(e => e.Id == id);
           Employers.Remove(e);
        }
    }
}
