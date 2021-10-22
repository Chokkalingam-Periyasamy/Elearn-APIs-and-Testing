using System;
using System.Collections.Generic;

#nullable disable

namespace ElearnStudentAPI.ElearnModel
{
    public partial class Module
    {
        public int Moduleid { get; set; }
        public int? Courseid { get; set; }
        public string Modulename { get; set; }
        public string Video { get; set; }
    }
}
