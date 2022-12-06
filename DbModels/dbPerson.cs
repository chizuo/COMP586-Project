using System.ComponentModel.DataAnnotations;
namespace Registration.DbModels
{
    public class dbPerson
    {
        [Key]
        public int id { get; set; }
        public string first { get; set; }
        public string? middle { get; set; }
        public string last { get; set; }
        public string Gender { get; set; }
        public int birthMonth { get; set; }
        public int birthDay { get; set; }
        public int birthYear { get; set; }
        public string email { get; set; }
        public string areaCode { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string personType { get; set; }
    }
}