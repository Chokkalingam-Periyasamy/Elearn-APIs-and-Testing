using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

#nullable disable

namespace ElearnCoursesAPI.ElearnModel
{
    public partial class Course:ICourse<Course>
    {
        public Course()
        {
            Usercourses = new HashSet<Usercourse>();
        }

        public int Courseid { get; set; }
        public string Coursename { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double? Amount { get; set; }

        public virtual ICollection<Usercourse> Usercourses { get; set; }
        public elearnContext db = new elearnContext();
        public List<Course> GetStuCourses(int id)
        {
            List<Course> courseDetail = new List<Course>();
            var registered = (from i in db.Usercourses where i.Stuid == id select i.Coid).ToList();
            courseDetail = (from i in db.Courses where !registered.Contains(i.Courseid) select i).ToList();
            return courseDetail;

        }
    }
}
