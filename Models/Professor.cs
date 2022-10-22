namespace Registration.Models
{
    public class Professor : Person
    {
        string title;
        /*
            Since Person has no constructor that takes 0 arguments,
            a constructor for Professor that calls the constructor of 
            Person with all the required arguments has been made.
        */
        public Professor(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string middleName, string email, int areaCode, int middleThree, int lastFour)
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, middleName, email, areaCode, middleThree, lastFour){
           title = "Professor";
        }

    }
}