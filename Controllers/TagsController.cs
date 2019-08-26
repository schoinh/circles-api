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
        private Circles_APIContext _db = new Circles_APIContext();
        private static int _currentPage = 1;
        private static int _entriesPerPage = 20;
        private static int _totalNumEntries;
        private static int _totalPages;
        private static int _prevPage;
        private static int _nextPage;

        // GET api/tags
        [HttpGet]
        public ActionResult<IEnumerable<Tag>> GetAll()
        {
            return _db.Tags.OrderBy(x => x.Name).ToList();
        }

        // GET api/tags/first (first page)
        [HttpGet("first")]
        public ActionResult<IEnumerable<Tag>> GetFirstPage()
        {
            var allTags = _db.Tags.ToList();
            _totalNumEntries = allTags.Count();
            _totalPages = (int)Math.Ceiling(_totalNumEntries / (float)_entriesPerPage);
            return _db.Tags
                .OrderBy(x => x.Name)
                .Take(_entriesPerPage).ToList();
        }

        // GET api/tags/next (next page)
        [HttpGet("next")]
        public ActionResult<IEnumerable<Tag>> GetNextPage()
        {
            _nextPage = _currentPage < _totalPages ? _currentPage + 1 : _totalPages;
            var output = _db.Tags
                .OrderBy(x => x.Name)
                .Skip((_nextPage - 1) * _entriesPerPage)
                .Take(_entriesPerPage)
                .ToList();
            if (_currentPage < _totalPages)
            {
                _currentPage += 1;
            }
            return output;
        }

        // GET api/tags/prev (previous page)
        [HttpGet("prev")]
        public ActionResult<IEnumerable<Tag>> GetPrevPage()
        {
            _prevPage = _currentPage > 1 ? _currentPage - 1 : 1;
            var output = _db.Tags
                .OrderBy(x => x.Name)
                .Skip((_prevPage - 1) * _entriesPerPage)
                .Take(_entriesPerPage)
                .ToList();
            if (_currentPage > 1)
            {
                _currentPage -= 1;
            }
            return output;
        }

        // GET api/tags/5 (retrieve a specific tag)
        [HttpGet("{id}")]
        public ActionResult<Tag> Get(int id)
        {
            return _db.Tags
                .Include(x => x.Userprofiles)
                .FirstOrDefault(x => x.TagId == id);
        }

        // POST api/tags
        [HttpPost]
        public void Post([FromBody] Tag tag)
        {
            _db.Tags.Add(tag);
            _db.SaveChanges();
        }

        // // PUT api/tags/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] Tag tag)
        // {
        //     tag.TagId = id;
        //     _db.Entry(tag).State = EntityState.Modified;
        //     _db.SaveChanges();
        // }

        // // DELETE api/tags/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //     var tagToDelete = _db.Tags.FirstOrDefault(x => x.TagId == id);
        //     _db.Tags.Remove(tagToDelete);
        //     _db.SaveChanges();
        // }
    }
}
