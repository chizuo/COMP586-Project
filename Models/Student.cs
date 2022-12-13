namespace Registration.Models
{
    public class Student : Person
    {
        protected List<Tuple<Course, double>> transcript;
        public List<Tuple<Course, double>> Transcript { get; set; }
        public double GPA { get { return overallGPA(); } }
        protected List<Section> cachedSections;
        public List<Section> Sections { get { return cachedSections; } }

        public Student(int id, string first, string last, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, string zip, string personType, List<Tuple<Course, double>>? transcript = null, Dictionary<string, List<Section>>? schedule = null, string middle = "", string email = "", string areaCode = "", string phone = "", List<Section>? cachedSections = null)
         : base(id, first, last, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middle, email, areaCode, phone)
        {
            this.transcript = transcript == null ? new List<Tuple<Course, double>>() : transcript;
            this.cachedSections = cachedSections != null ? cachedSections : new List<Section>();
        }

        public double overallGPA()
        {
            double gradePoints = 0.0;
            int unitsTaken = 0;
            foreach (var grade in transcript)
            {
                unitsTaken += grade.Item1.Units;
                gradePoints += grade.Item2;
            }
            return Math.Truncate((gradePoints / unitsTaken) * 100) / 100;
        }

        /* provides a List<string> of course catalog names for comparison purposes */
        public List<string> coursesPassed()
        {
            var courseList = new List<string>();
            foreach (var course in transcript)
            {
                if (course.Item2 >= 2.0)
                {
                    courseList.Add(course.Item1.Code);
                    Console.Write("Course passed - ");
                    Console.WriteLine(course.Item1.Code);
                }
            }
            return courseList;
        }
    }
}