namespace Registration.Models
{
    public class Course
    {
        protected Department department;
        protected int number;
        protected string subject;
        public string Subject { get; }
        public string Name { get { return department.Code + number.ToString() + " : " + subject; } }
        public string Code { get { return isLab == true ? department.Code + number.ToString() + "L" : department.Code + number.ToString(); } }
        protected int units;
        public int Units { get { return units; } }
        protected bool isLab; /* identifies if this course is a lab */
        public bool IsLab { get { return isLab; } }
        internal Course lab; /* couse that is the lab component */
        internal string description;
        protected HashSet<Course> preRequisites;
        public HashSet<Course> PreRequisites { set { preRequisites = value; } }
        public List<Course> PreReq { get { return preRequisites.ToList(); } }
        protected HashSet<Course> coRequisites;
        public HashSet<Course> CoRequisites { set { coRequisites = value; } }
        public List<Course> CoReq { get { return coRequisites.ToList(); } }

        public Course(Department department, int number, string subject, int units, string courseDescription, HashSet<Course> preReq, HashSet<Course> coReq, bool isLab = false)
        {
            this.department = department;
            this.number = number;
            this.subject = subject;
            this.units = units;
            this.lab = lab;
            this.description = courseDescription;
            this.preRequisites = preReq;
            this.coRequisites = coReq;
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
                preReqs.Add(course.Code);
            }

            /* Convert course object to course name for comparison */
            foreach (var course in coRequisites)
            {
                coReqs.Add(course.Code);
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