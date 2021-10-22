using ElearnStudentAPI.ElearnModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnStudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public elearnContext db = new elearnContext();
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.Users.ToListAsync());
        }

        [HttpPost]
        [Route ("Mycourse")]
        public IActionResult MyCourse(Usercourse e,int myid)
        {
            using (var oc = new elearnContext())
            {
               Course MyDetail = (from i in oc.Courses
                            join cd in oc.Usercourses on i.Courseid equals cd.Coid
                            where cd.Stuid == myid
                            select i).FirstOrDefault();
                return Ok();

            }

        }
        

        [HttpPost]
        [Route ("UserEnroll")]
        public async Task<IActionResult> Enrolls(Usercourse s)
        {
            db.Usercourses.Add(s);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Adduser(User s)
        {
            db.Users.Add(s);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> update(User e,int id)
        {
            using(var db= new elearnContext())
            { 
            db.Entry(e).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(e);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            User e = db.Users.Find(id);
            db.Users.Remove(e);
            await db.SaveChangesAsync();
            return Ok(e);
        }
        [HttpGet]
        [Route("GetByID")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            User e = await db.Users.FindAsync(id);
            return Ok(e);
        }
        

    }
}
