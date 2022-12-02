using System.ComponentModel.DataAnnotations;
namespace Registration.DbModels
{
    public class dbCoreReq
    {
        [Key]
        public string course_Id { get; set; }
        public string coreq_Id { get; set; }
    }
}