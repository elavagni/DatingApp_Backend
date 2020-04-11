using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using DatingApp.API.Models.C7;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {        
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        private void Log(string messega) { }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        #region C7 features
        private void TestingSwitch()
        {
            Document document = new Draft();
            switch (document)
            {
                case Bill billHR when (billHR.Type == "HR"):
                    Log("HR Bill detected");
                    break;
                case Bill bill:
                    Log("Bill detected");
                    break;
                case Draft draft:
                    Log("Draft detected");
                    break;
                case Document doc:
                    Log("Document detected");
                    break;
                default:
                    Log("Different type of document detected");
                    break;
            }
        }
        private void TestingIf()
        {
            Document doc = new Draft();

            //before 
            var draft = doc as Draft;
            if (draft != null)
            {
                //do stuff
            }

            //now
            if (doc is Draft draft1)
            {
                //do stuff
            }
        }
        #endregion
    }
}