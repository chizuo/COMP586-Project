using System.ComponentModel.DataAnnotations;
namespace Registration.DbModels
{
    public class dbSection
    {
        [Key]
        public int section_id { get; set; }
        public int sectionNumber { get; set; }
        public string schoolYear { get; set; }
        public string schoolTerm { get; set; }
        public int enrollmentCap { get; set; }
        public int waitListcap { get; set; }
        public int startTme { get; set; }
        public int endTime { get; set; }
        public string classLocation { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public string classNote { get; set; }
    }
}