namespace Registration.Models
{
    public class CourseView
    {
        public string dept;
        public int number;
        public string name;
        public int units;
        public string description;

        public CourseView(string deptName, int courseNumber, string courseName, int units, string courseDescription)
        {
            dept = deptName;
            number = courseNumber;
            name = courseName;
            this.units = units;
            description = courseDescription;
        }
    }
}