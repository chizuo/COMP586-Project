using System.ComponentModel.DataAnnotations;

namespace Registration.DbModels
{
    public class dbStudent
    {
        [Key]
        public string student_id { get; set; }
        public int sectionNumber { get; set; }
        public string course_id { get; set; }
        public string grade { get; set; }
    }
}