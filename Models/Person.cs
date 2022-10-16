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
        public int birthMonth { get; set; }
        public int birthDay { get; set; }
        public int birthYear {get; set;}
        public string? email {get; set;}
        public int? areaCode {get; set;}    //constitutes the formation of a phone number (areaCode) (middleThree)-(lastFour)
        public int? middleThree {get; set;}
        public int? lastFour {get; set;}
        public string  address {get; set;}
        public string city {get; set;}
        public string state {get; set;}
        public int zip {get; set;}

        //Main Constructor -> if person contains all fields
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string middleName, string email, int areaCode, int middleThree, int lastFour){
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.email =  email;
            this.areaCode = areaCode;
            this.middleThree = middleThree;
            this.lastFour = lastFour;
        }
        
        //if person doesn't contain a middle name
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string email, int areaCode, int middleThree, int lastFour){
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.email =  email;
            this.areaCode = areaCode;
            this.middleThree = middleThree;
            this.lastFour = lastFour;
        }

        //if person doesn't contain a middle name & phone number
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string email){
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.email = email;
        }

        //if person doesn't contain a middle name & email 
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear,  string address, string city, string state, int zip, int areaCode, int middleThree, int lastFour){
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.areaCode = areaCode;           
            this.middleThree = middleThree;
            this.lastFour = lastFour;           
        }

        //if person doesn't contain a middle name & email & phone number
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip){
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }
        
        
       

    }
}