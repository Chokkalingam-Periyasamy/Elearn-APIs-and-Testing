using ElearnStaffAPI.ElearnModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnStaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public elearnContext db = new elearnContext();

        [HttpGet]
        public async Task<IActionResult> GetAllStaffs()
        {
            return Ok(await db.staff.ToListAsync());
        }
        [HttpGet]
        [Route("GetStaffByID")]
        public async Task<ActionResult<staff>> GetStaffById(int Id)
        {
            staff e = await db.staff.FindAsync(Id);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(staff s)
        {
            db.staff.Add(s);
            await db.SaveChangesAsync();
            return Ok();
        }
      

        [HttpPut]
        public async Task<IActionResult> UpdateStaff(int Id, staff s)
        {
            using (var db = new elearnContext())
            {

                if (Id != s.Staffid)
                {
                    return BadRequest();
                }

                db.Entry(s).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            staff e = db.staff.Find(id);
            db.staff.Remove(e);
            await db.SaveChangesAsync();
            return Ok();
        }

        private bool StaffExists(int Id)
        {
            return db.staff.Any(s => s.Staffid == Id);
        }

        [HttpPost]
        [Route("StaffLogin")]
        public async Task<IActionResult> Login(staff e)
        {
            staff a = (from i in db.staff where i.Email == e.Email && i.Password == e.Password select i)
                .FirstOrDefault();
            return Ok(a);
        }

    }
}
