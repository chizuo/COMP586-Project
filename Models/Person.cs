using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string? middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int birthDay {get; set; }
        public int birthYear {get; set; }
        public string? email {get; set; }
        public string? phoneNumber {get; set;}
        public string  address {get; set;}
        public string city {get; set;}
        public string state {get; set;}
        public int zip {get; set;}

        public Person(string firstName, string lastName, string gender, int birthDay, int birthYear, string address, string city, string state, int zip){
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

    }
}