using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Student_Course_ManagmentSystem.DataModels
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<Grade> Grades { get; set; }
    }
}