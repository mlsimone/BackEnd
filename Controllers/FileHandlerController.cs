using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndPoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileHandlerController : ControllerBase
    {
        // GET: api/<FileHandlerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FileHandlerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<FileHandlerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // POST: api/Items1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostPictures(List<IFormFile> battlePlans)
        {
            long size = battlePlans.Sum(f => f.Length);

            foreach (var formFile in battlePlans)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = battlePlans.Count});
            //return Ok(new { count = battlePlans.Count, size });
        }

        // PUT api/<FileHandlerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileHandlerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
