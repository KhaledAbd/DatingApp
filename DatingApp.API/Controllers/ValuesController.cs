using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;
        public ValuesController(DataContext context)
        {
            this.context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            return Ok(await context.Values.ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            return Ok(await context.Values.FirstOrDefaultAsync(V => V.Id == id));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await context.AddAsync<Value>(new Value {
                Name = value
            });
            await context.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
