using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoolApi.Data;
using PoolApi.Models;

namespace PoolApi.Controllers
{
    public class PoolController : ControllerBase
    {
        private readonly PoolContext _context;
        public PoolController(PoolContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [Route("poll/{id}")]
        // GET pool/:id
        [HttpGet]
        public async Task<IActionResult> GetValues(int id)
        {
            var values =  _context.Values.Find(id);

            PoolDatabase Poll = new PoolDatabase()
            {
                Id = values.poll_id,
                Description = values.poll_description,
            };

            var options = JArray.Parse
            (JsonConvert.SerializeObject
                (_context.Options.
                    Where(o => o.poll_id == id).Select(o => new { o.option_id, o.option_description }).
                        ToArray()));

            return Ok(new { poll_id = values.poll_id, poll_description = values.poll_description, options = options });
        }

        [Route("poll/{id}/stats")]
        // GET Get /poll/:id/stats
        [HttpGet]
        public async Task<IActionResult> GetValuesIdStats(int id)
        {
            var views = _context.Views.Where(x => x.poll_id == id).Count();

            if (views == null)
            {
                return NotFound();
            }

            var votes = JArray.Parse(JsonConvert.SerializeObject(
                from o in _context.Options.Where(option => option.poll_id == id)
                select new
                {
                    option_id = o.option_id,
                    qty = _context.Votes.Where(v => v.option_id == o.option_id).Count()
                }
            ));

            return Ok(new { views = views, votes });
        }

        //POST: /poll
        [HttpPost]
        [Route("pool")]
        public async Task<IActionResult> Post(PoolContext context, int id)
        {
            var values = await _context.Options.ToListAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.SaveChanges();

            return Ok(values);
        }
    }
}