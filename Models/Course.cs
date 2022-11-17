namespace Registration.Models
{
    public class Course
    {
        public string dept;
        public int number;
        public string name;
        public int units;
        public string description;
        public HashSet<Course> preRequisites;
        public HashSet<Course> coRequisites;

        public Course(string deptName, int courseNumber, string courseName, int units, string courseDescription, HashSet<Course> preReq, HashSet<Course> coReq)
        {
            dept = deptName;
            number = courseNumber;
            name = courseName;
            this.units = units;
            description = courseDescription;
            preRequisites = preReq;
            coRequisites = coReq;
        }

        /* Method to concatenate certain fields to provide a catalog name for the course */
        public string getName()
        {
            return dept + number.ToString() + ": " + name;
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