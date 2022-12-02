using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Registration.DbModels
{
    public class dbCourse
    {
        [Key]
        public string course_Id { get; set; }
        public string department { get; set; }
        public int number { get; set; }
        public string subject { get; set; }
        public int units { get; set; }
        public bool isLab { get; set; }
        public string description { get; set; }
    }
}