using System;
using System.Collections.Generic;

#nullable disable

namespace EleranModuleAPI.ElearnModel
{
    public partial class User
    {
        public User()
        {
            Usercourses = new HashSet<Usercourse>();
        }

        public int Userid { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Usercourse> Usercourses { get; set; }
    }
}
