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
    public class CircleUserprofilesController : ControllerBase
    {
        private Circles_APIContext _db = new Circles_APIContext();

        // DELETE api/circleuserprofiles/5
        [HttpDelete("{id}")]
        public void DeleteJoin(int id)
        {
            var joinEntry = _db.CircleUserprofiles.FirstOrDefault(entry => entry.CircleUserprofileId == id);
            _db.CircleUserprofiles.Remove(joinEntry);
            _db.SaveChanges();
        }
    }
}