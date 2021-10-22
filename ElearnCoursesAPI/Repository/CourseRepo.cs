using ElearnCoursesAPI.ElearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnCoursesAPI.Repository
{
    public class CourseRepo : ICourseRepo<Course>
    {
        private readonly ICourse<Course> obj;
        public CourseRepo(ICourse<Course> _obj)
        {
            obj = _obj;
        }
        public List<Course> GetStuCourses(int id)
        {
            return obj.GetStuCourses(id);
        }
    }
}
