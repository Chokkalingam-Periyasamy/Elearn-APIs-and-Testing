using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnCoursesAPI.ElearnModel
{
    public interface ICourse<Course>
    {
        public List<Course> GetStuCourses(int id);
    }
}
