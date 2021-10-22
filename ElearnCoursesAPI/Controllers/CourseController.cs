using ElearnCoursesAPI.ElearnModel;
using ElearnCoursesAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnCoursesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public elearnContext db = new elearnContext();

        
       
        public static List<Course> atc = new List<Course>();


        [HttpGet]
        [Route("GetCourseByUserId")]
        public IActionResult GetCartByUserId(int myid)
        {
            using (var oc = new elearnContext())
            {
                List<Course> MyDetail = new List<Course>();
                MyDetail = (from i in oc.Courses
                            join cd in oc.Usercourses on i.Courseid equals cd.Coid
                            where cd.Stuid == myid
                            select i).ToList();

                return Ok(MyDetail);
            }

           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await db.Courses.ToListAsync());
        }
   

        private readonly ICourseServ<Course> serv2;
        public CourseController(ICourseServ<Course> _serv2)
        {
            serv2 = _serv2;
        }
        [HttpGet]
        [Route("GetStudentCourse")]
        public IActionResult GetStuCourses(int id)
        {
            List<Course> courseDetail = new List<Course>();
            //var registered = (from i in db.Usercourses where i.Stuid == id select i.Coid).ToList();
            //courseDetail = (from i in db.Courses where !registered.Contains(i.Courseid) select i).ToList();
            //return Ok(courseDetail);
            courseDetail =  serv2.GetStuCourses(id);
            return Ok(courseDetail);

        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course a)
        {
            db.Courses.Add(a);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(Course e, int id)
        {
            using (var db = new elearnContext())
            {
                db.Entry(e).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(e);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            Course e = db.Courses.Find(id);
            db.Courses.Remove(e);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("GetByCourseID")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            Course e = await db.Courses.FindAsync(id);
            return Ok(e);
        }

    }
}
