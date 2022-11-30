using System.ComponentModel.DataAnnotations;

namespace Registration.DbModels
{
    public class dbAddnumbers
    {
        [Key]
        public int sectionNumber { get; set; }
        public int addNumber { get; set; }
    }
}