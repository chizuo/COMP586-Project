using System.ComponentModel.DataAnnotations;
namespace Registration.DbModels
{
    public class dbPreReq
    {
        [Key]
        public string course_Id { get; set; }
        public string prereq_Id { get; set; }
    }
}