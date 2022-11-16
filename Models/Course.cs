namespace Registration.Models
{
    public class Course
    {
        public string deptName;
        public int courseNumber;
        public string courseName;
        public int units;
        public string courseDescription;
        public HashSet<Course> preRequisites;
        public HashSet<Course> coRequisites;

        public Course(string deptName, int courseNumber, string courseName, int units, string courseDescription, HashSet<Course> preReq, HashSet<Course> coReq)
        {
            this.deptName = deptName;
            this.courseNumber = courseNumber;
            this.courseName = courseName;
            this.units = units;
            this.courseDescription = courseDescription;
            this.preRequisites = preReq;
            this.coRequisites = coReq;
        }

        /* Method to concatenate certain fields to provide a catalog name for the course */
        public string getName()
        {
            return deptName + courseNumber.ToString() + ": " + courseName;
        }

        /* Method that checks if the student meets the requirement to take this course */
        public Boolean requirements(Student student)
        {
            int coReqHits = 0;
            int preReqHits = 0;
            var coReqs = new HashSet<string>();
            var preReqs = new HashSet<string>();

            /* Convert course object to course name for comparison */
            foreach (var course in preRequisites)
            {
                preReqs.Add(course.getName());
            }

            /* Convert course object to course name for comparison */
            foreach (var course in coRequisites)
            {
                coReqs.Add(course.getName());
            }

            foreach (var course in student.coursesPassed())
            {
                if (coReqs.Contains(course)) ++coReqHits;
                if (preReqs.Contains(course)) ++preReqHits;
            }

            /* if corequisites are not met, check if student is currently taking it */
            if (coReqHits != coReqs.Count())
            {
                foreach (var course in student.coursesInSchedule())
                {
                    if (coReqs.Contains(course)) ++coReqHits;
                }
            }

            return (coReqHits == coReqs.Count() && preReqHits == preReqs.Count());
        }
    }
}