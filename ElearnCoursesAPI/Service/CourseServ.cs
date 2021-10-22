using ElearnCoursesAPI.ElearnModel;
using ElearnCoursesAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElearnCoursesAPI.Service
{
    public class CourseServ:ICourseServ<Course>
    {
        private readonly ICourseRepo<Course> repo;
        public CourseServ(ICourseRepo<Course> _repo)
        {
            repo = _repo;
        }

        public List<Course> GetStuCourses(int id)
        {
            return repo.GetStuCourses(id);
        }
    }
}
