namespace Registration.Models
{
    public class Course
    {
        /*
        Dept: COMP
        CourseNum: 586
        Course Name: Object-Oriented Software Development
        Full Course Name : COMP 586 Object-Oriented Software Development
        Description: string
        PreReq: list of strings
        CoReq: list of strings
        */

        public string deptName;
        public int courseNumber;
        public string courseName;
        public string courseDescription;
        public List<Course> preRequisites;
        public List<Course> coRequisites;

        public Course(string deptName, int courseNumber, string courseName, string courseDescription, List<Course> preReq, List<Course> coReq)
        {
            this.deptName = deptName;
            this.courseNumber = courseNumber;
            this.courseName = courseName;
            this.courseDescription = courseDescription;
            this.preRequisites = preReq;
            this.coRequisites = coReq;
        }

        public string getName()
        {
            return deptName + courseNumber.ToString() + ": " + courseName;
        }

    }
}