using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class Course
    {
        /*
        Dept: COMP
        CourseNum: 586
        Name: concat Dept & CourseNum
        Description: string
        PreReq: list of strings
        CoReq: list of strings
        */

        public string deptName;
        public int courseNumber;
        public string courseDescription;
        public List<Course> preRequisites;
        public List<Course> courseRequisites;

        public Course(string deptName, int courseNumber, string courseDescription, List<Course> preReq, List<Course> coReq)
        {
            this.deptName = deptName;
            this.courseNumber = courseNumber;
            this.courseDescription = courseDescription;
            this.preRequisites = preReq;
            this.courseRequisites = coReq;
        }

        public string concatName
        {
            get { return deptName + courseNumber.ToString(); }
        }

    }
}