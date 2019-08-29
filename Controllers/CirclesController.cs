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
    public class CirclesController : ControllerBase
    {
        private Circles_APIContext _db;
        private static int _currentPage = 1;    // Must be 1
        private static int _entriesPerPage = 4;     // This can be changed
        private static int _totalNumEntries;
        private static int _totalPages;
        private static int _prevPage;
        private static int _nextPage;

           public CirclesController(Circles_APIContext db)
        {
            _db = db;
        }

        // GET api/circles
        [HttpGet]
        public ActionResult<IEnumerable<Circle>> GetAll()
        {
            return _db.Circles
                .Include(x => x.Userprofiles)
                .ThenInclude(join => join.Userprofile)
                .OrderBy(x => x.Name).ToList();
        }

        // GET api/circles/first (first page)
        [HttpGet("first")]
        public ActionResult<IEnumerable<Circle>> GetFirstPage()
        {
            var allCircles = _db.Circles.ToList();
            _totalNumEntries = allCircles.Count();
            _totalPages = (int)Math.Ceiling(_totalNumEntries / (float)_entriesPerPage);
            return _db.Circles
                .OrderBy(x => x.Name)
                .Take(_entriesPerPage).ToList();
        }

        // GET api/circles/next (next page)
        [HttpGet("next")]
        public ActionResult<IEnumerable<Circle>> GetNextPage()
        {
            _nextPage = _currentPage < _totalPages ? _currentPage + 1 : _totalPages;
            var output = _db.Circles
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

        // GET api/circles/prev (previous page)
        [HttpGet("prev")]
        public ActionResult<IEnumerable<Circle>> GetPrevPage()
        {
            _prevPage = _currentPage > 1 ? _currentPage - 1 : 1;
            var output = _db.Circles
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

        // GET api/circles/5 (retrieve a specific circle)
        [HttpGet("{id}")]
        public ActionResult<Circle> Get(int id)
        {
            return _db.Circles
                .Include(x => x.Userprofiles)
                .ThenInclude(join => join.Userprofile)
                .FirstOrDefault(x => x.CircleId == id);
        }

        // POST api/circles
        [HttpPost]
        public void Post([FromBody] Circle circle)
        {
            _db.Circles.Add(circle);
            _db.SaveChanges();
        }

        // PUT api/circles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Circle circle)
        {
            circle.CircleId = id;
            _db.Entry(circle).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/circles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var circleToDelete = _db.Circles.FirstOrDefault(x => x.CircleId == id);
            _db.Circles.Remove(circleToDelete);
            _db.SaveChanges();
        }

        // POST api/circles/1/userprofiles/3
        [HttpPost("{circleId}/userprofiles/{userprofileId}")]
        public void AddUserprofile(int circleId, int userprofileId)
        {
            _db.CircleUserprofiles.Add(new CircleUserprofile() { CircleId = circleId, UserprofileId = userprofileId });
            //var circleToModify = _db.Userprofiles.Where(x => x.UserprofileId == userprofileId);
            // _db.Entry(userprofile).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
