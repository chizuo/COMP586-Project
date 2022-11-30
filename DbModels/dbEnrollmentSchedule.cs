using System.ComponentModel.DataAnnotations;

namespace Registration.DbModels
{
    public class dbEnrollmentSchedule
    {
        [Key]
        public int id { get; set; }
        public int sectionNumber { get; set; }
    }
}