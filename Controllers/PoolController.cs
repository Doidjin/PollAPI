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
        public async Task<IActionResult> Post(PoolDatabase context, int id)
        {
            var pollModel = new PoolDatabase()
            {
                poll_description = context.Description
            };

                using (var PollDBContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Values.Add(pollModel);
                        _context.SaveChanges();
                        context.poll_id = pollModel.poll_id;

                        ICollection<Option> options = new HashSet<Option>();
                        _context.Options.ToList().ForEach(
                            description => options.Add(
                                new Option()
                                {
                                    option_description = description.ToString(),
                                    poll_id = context.Id
                                })
                            );

                        _context.Options.AddRange(options);
                        _context.SaveChanges();
                        PollDBContextTransaction.Commit();
                    }

                    catch (Exception ex)
                    {
                        PollDBContextTransaction.Rollback();
                    }
            }
            return Ok(new { poll_id = context.Id });
        }
    }
}