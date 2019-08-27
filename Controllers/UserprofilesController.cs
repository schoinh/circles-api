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
    public class UserprofilesController : ControllerBase
    {
        private Circles_APIContext _db = new Circles_APIContext();
        private static int _currentPage = 1;    // Must be 1
        private static int _entriesPerPage = 4;     // This can be changed
        private static int _totalNumEntries;
        private static int _totalPages;
        private static int _prevPage;
        private static int _nextPage;

        // GET api/userprofiles
        // Optional query parameter keys: gender, location
        [HttpGet]
        public ActionResult<IEnumerable<Userprofile>> GetAll(string gender = null, string location = null)
        {
            if (gender == null && location == null)
            {
                return _db.Userprofiles.OrderBy(x => x.Name).ToList();
            }
            else if (gender == null)
            {
                return _db.Userprofiles
                    .Where(x => x.Location == location)
                    .OrderBy(x => x.Name).ToList();
            }
            else if (location == null)
            {
                return _db.Userprofiles
                    .Where(x => x.Gender == gender)
                    .OrderBy(x => x.Name).ToList();
            }
            else
            {
                return _db.Userprofiles
                    .Where(x => x.Location == location)
                    .Where(x => x.Gender == gender)
                    .OrderBy(x => x.Name).ToList();
            }
        }

        // GET api/userprofiles/first (first page)
        [HttpGet("first")]
        public ActionResult<IEnumerable<Userprofile>> GetFirstPage()
        {
            var allUserprofiles = _db.Userprofiles.ToList();
            _totalNumEntries = allUserprofiles.Count();
            _totalPages = (int)Math.Ceiling(_totalNumEntries / (float)_entriesPerPage);
            return _db.Userprofiles
                .OrderBy(x => x.Name)
                .Take(_entriesPerPage).ToList();
        }

        // GET api/userprofiles/next (next page)
        [HttpGet("next")]
        public ActionResult<IEnumerable<Userprofile>> GetNextPage()
        {
            _nextPage = _currentPage < _totalPages ? _currentPage + 1 : _totalPages;
            var output = _db.Userprofiles
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

        // GET api/userprofiles/prev (previous page)
        [HttpGet("prev")]
        public ActionResult<IEnumerable<Userprofile>> GetPrevPage()
        {
            _prevPage = _currentPage > 1 ? _currentPage - 1 : 1;
            var output = _db.Userprofiles
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

        // GET api/userprofiles/5 (retrieve a specific userprofile)
        [HttpGet("{id}")]
        public ActionResult<Userprofile> Get(int id)
        {
            return _db.Userprofiles
                // .Include(x => x.Tags)
                // .ThenInclude(join => join.Tag)
                .FirstOrDefault(x => x.UserprofileId == id);
        }

        // POST api/userprofiles
        [HttpPost]
        public void Post([FromBody] Userprofile userprofile)
        {
            _db.Userprofiles.Add(userprofile);
            _db.SaveChanges();
        }

        // PUT api/userprofiles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Userprofile userprofile)
        {
            userprofile.UserprofileId = id;
            _db.Entry(userprofile).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/userprofiles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var userprofileToDelete = _db.Userprofiles.FirstOrDefault(x => x.UserprofileId == id);
            _db.Userprofiles.Remove(userprofileToDelete);
            _db.SaveChanges();
        }

        // POST api/userprofiles/1/tags/3
        [HttpPost("{userprofileId}/tags/{tagId}")]
        public void AddTag(int userprofileId, int tagId)
        {
            _db.TagUserprofiles.Add(new TagUserprofile() { TagId = tagId, UserprofileId = userprofileId });
            //var circleToModify = _db.Userprofiles.Where(x => x.UserprofileId == userprofileId);
            // _db.Entry(userprofile).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
