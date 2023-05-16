using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Student_Course_ManagmentSystem.DataModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set;}
        public int Age { get; set; }
        public string Gender { get; set; }
        [JsonIgnore]
        public List<Grade> Grades { get; set; }
    }
}
