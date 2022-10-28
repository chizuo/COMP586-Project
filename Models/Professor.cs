namespace Registration.Models
{
    public class Professor : Person
    {
        Dictionary<string, Section>? semesterSections;

        public Professor(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "", Dictionary<string, Section>? semesterSections = null)
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = "")
        {
            this.semesterSections = semesterSections != null ? semesterSections : new Dictionary<string, Section>();
        }
    }
}