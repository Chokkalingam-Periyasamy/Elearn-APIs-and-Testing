using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ElearnStudentAPI.ElearnModel
{
    public partial class staff
    {
        public int Staffid { get; set; }


        [Required(ErrorMessage = "Please add a Name")]
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Expertise { get; set; }
        [Required(ErrorMessage = "Please enter Phone number")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Phone number should be of 10 digits")]
        [Display(Name = "Phone Number")]
        public string Mobile { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
