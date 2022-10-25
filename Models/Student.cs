namespace Registration.Models
{
    public class Student : Person
    {
        protected Dictionary<string, List<Section>> coursesTaken;

        public Student(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, Dictionary<string, List<Section>>? coursesTaken = null, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "")
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = "")
        {
            this.coursesTaken = coursesTaken == null ? new Dictionary<string, List<Section>>() : coursesTaken;
        }
        public void calculateGPA()
        {

        }
    }
}