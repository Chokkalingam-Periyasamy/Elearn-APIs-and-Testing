using ElearnCoursesAPI.ElearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnCoursesAPI.Repository
{
    public interface ICourseRepo<Course>
    {
        public List<Course> GetStuCourses(int id);
    }
}
