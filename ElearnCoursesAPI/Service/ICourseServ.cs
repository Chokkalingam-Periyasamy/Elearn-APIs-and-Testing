using ElearnCoursesAPI.ElearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnCoursesAPI.Service
{
   public  interface ICourseServ<Course>
    {
        public List<Course> GetStuCourses(int id);
    }
}
