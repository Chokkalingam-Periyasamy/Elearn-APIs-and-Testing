using System;
using System.Collections.Generic;

#nullable disable

namespace ElearnCoursesAPI.ElearnModel
{
    public partial class staff
    {
        public int Staffid { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Expertise { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
