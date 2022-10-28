namespace Registration.Models
{

    public class Section
    {
        protected Course course;
        protected Professor professor;
        public int classSectionNumber;
        public string schoolYear;
        public string schoolTerm;
        public int enrollmentCap;
        public List<Student> enrollment;
        public int waitListcap;
        public int waitListTotal;
        public string[] classDays;
        /* Time is in minutes of the day in a 24 hour clock starting at 0 (00:00) to 1439 (23:59) */
        public int startTime;
        public int endTime;
        public string classLocation;
        public DateOnly startDate;
        public DateOnly endDate;
        public string classNote;
        public Dictionary<int, Boolean> addNumbers = new Dictionary<int, Boolean>();

        public Section(Course course, int classSectionNumber, string schoolTerm, string schoolYear, int enrollmentCap, List<Student> enrollment, int waitListcap, int waitListTotal, string[] classDays, int startTime, int endTime, string classLocation, string classMeetingDates, string classNote, Dictionary<int, Boolean> addNumbers, Professor professor = null)
        {
            this.course = course;
            this.classSectionNumber = classSectionNumber;
            this.schoolTerm = schoolTerm;
            this.schoolYear = schoolYear;
            this.enrollmentCap = enrollmentCap;
            this.enrollment = enrollment;
            this.waitListcap = waitListcap;
            this.waitListTotal = waitListTotal;
            this.classDays = classDays;
            this.startTime = startTime;
            this.endTime = endTime;
            this.classLocation = classLocation;
            this.classNote = classNote;
            this.addNumbers = addNumbers;
            this.professor = professor;
        }

        public int generateAddNumber()
        {
            Random rand = new Random();
            int addNumber;
            do
            {
                addNumber = rand.Next(10000, 99999);
            } while (addNumbers.ContainsKey(addNumber));

            addNumbers.Add(addNumber, false);

            return addNumber;
        }

        public bool addStudent(Student student)
        {
            if (enrollment.Count != enrollmentCap)
            {
                enrollment.Add(student);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addStudent(Student student, int addNumber)
        {
            if (addNumbers.ContainsKey(addNumber) && addNumbers[addNumber] == false)
            {
                addNumbers[addNumber] = true;
                enrollment.Add(student);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addProfessor(Professor prof)
        {
            professor = prof;
            return true;
        }
        public string getProfessorFullName()
        {
            if (professor != null) return professor.getName();

            return "Staff";
        }

        public bool replaceProfessor(Professor prof, Section section)
        {

            if (prof.scheduler(section) == true)
            {
                if (professor == null)
                {
                    addProfessor(prof);
                    prof.addSection(section);
                    return true;
                }
                else
                {
                    professor.removeSection(section);
                    addProfessor(prof);
                    prof.addSection(section);
                    return true;
                }
            }

            return false;
        }

        public string getCourseName()
        {
            return course.getName();
        }

        public int getUnits()
        {
            return course.units;
        }
    }
}
