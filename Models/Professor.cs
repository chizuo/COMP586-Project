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
        public Professor(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "")
         : base(firstName,  lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = ""){
           title = "Professor";
        }

        // public Boolean availability(Section section); ready upon Person class no longer being abstract

    }
}