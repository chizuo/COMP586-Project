using System.ComponentModel.DataAnnotations;

namespace Registration.DbModels
{
    public class dbClassDays
    {
        [Key]
        public int sectionNumber { get; set; }
        public string class_day { get; set; }
    }
}