using System.ComponentModel.DataAnnotations;
namespace Registration.DbModels
{
    public class dbSection
    {

        //public int section_id { get; set; }
        [Key]
        public int sectionNumber { get; set; }
        public string dept { get; set; }
        public string course_Id { get; set; }
        public string schoolYear { get; set; }
        public string schoolTerm { get; set; }
        public int enrollmentCap { get; set; }
        public int waitListcap { get; set; }
        public int waitListTotal { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public string classLocation { get; set; }
        //public DateOnly startDate { get; set; }
        //public DateOnly endDate { get; set; }
        public string classNote { get; set; }
    }
}