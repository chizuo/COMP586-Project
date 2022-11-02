namespace Registration.Models
{
    public class Student : Person
    {
        public List<Tuple<Section, double>> transcript;

        public Student(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, List<Tuple<Section, double>>? transcript = null, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "")
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = "")
        {
            this.transcript = transcript == null ? new List<Tuple<Section, double>>() : transcript;
        }

        public double overallGPA()
        {
            double gradePoints = 0.0;
            int unitsTaken = 0;
            foreach (var grade in transcript)
            {
                unitsTaken += grade.Item1.getUnits();
                gradePoints += grade.Item2;
            }
            return Math.Truncate((gradePoints / unitsTaken) * 100) / 100;
        }

        /* provides a List<string> of course catalog names for comparison purposes */
        public List<string> coursesPassed()
        {
            var courseList = new List<string>();
            foreach (var section in this.transcript)
            {
                if (section.Item2 >= 2.0)
                    courseList.Add(section.Item1.getCourseName());
            }
            return courseList;
        }
    }
}