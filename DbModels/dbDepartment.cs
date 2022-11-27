using Registration.Models;
using System.ComponentModel.DataAnnotations;
namespace Registration.DbModels
{
    public class dbDepartment
    {
        public string name { get; set; }
        [Key]
        public string code { get; set; }
        //public Professor? professor { get; set; }
    }
}