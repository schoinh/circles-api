using Circles_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Circles_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private Circles_APIContext _db;

         public TagsController(Circles_APIContext db)
        {
            _db = db;
        }

        // GET api/tags
        [HttpGet]
        public ActionResult<IEnumerable<Tag>> GetAll()
        {
            return _db.Tags
                .Include(x => x.Userprofiles)
                .ThenInclude(join => join.Userprofile)
                .OrderBy(x => x.Name).ToList();
        }

        // GET api/tags/5 (retrieve a specific tag)
        [HttpGet("{id}")]
        public ActionResult<Tag> Get(int id)
        {
            return _db.Tags
                .Include(x => x.Userprofiles)
                .ThenInclude(join => join.Userprofile)
                .FirstOrDefault(x => x.TagId == id);
        }

        // POST api/tags
        [HttpPost]
        public void Post([FromBody] Tag tag)
        {
            _db.Tags.Add(tag);
            _db.SaveChanges();
        }
    }
}
