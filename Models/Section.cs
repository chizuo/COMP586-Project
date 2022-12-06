using System.Globalization;
namespace Registration.Models
{
    public class Section
    {
        protected Course course;
        public Course Course {get { return course; } }
        protected Professor? professor;
        public int sectionNumber;
        public string schoolYear;
        public string schoolTerm;
        public int enrollmentCap;
        public List<Student> enrollment = new List<Student>();
        public int waitListcap;
        public int waitListTotal;
        public string[] classDays;
        /* Time is in minutes of the day in a 24 hour clock starting at 0 (00:00) to 1439 (23:59) */
        public int? startTime;
        public int? endTime;
        public string classLocation;
        public DateOnly startDate;
        public DateOnly endDate;
        public string classNote;
        public Dictionary<int, Boolean> addNumbers = new Dictionary<int, Boolean>();

        public Section(Course course, int sectionNumber, string schoolTerm, string schoolYear, int enrollmentCap, int waitListcap, int waitListTotal, string[] classDays, int startTime, int endTime, string classLocation, string classMeetingDates, string classNote, Dictionary<int, Boolean> addNumbers, Professor? professor = null)
        {
            this.course = course;
            this.sectionNumber = sectionNumber;
            this.schoolTerm = schoolTerm;
            this.schoolYear = schoolYear;
            this.enrollmentCap = enrollmentCap;
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

        public bool removeStudent(Student student)
        {
            int index = 0;
            foreach (Student students in enrollment)
            {
                if (student.ID == students.ID)
                {
                    enrollment.RemoveAt(index);
                    return true;
                }
                index++;
            }
            return false;
        }

        public bool addProfessor(Professor prof, Section section)
        {
            professor = prof;
            prof.addSection(section);
            prof.cacheSection(section);
            return true;
        }

        public bool replaceProfessor(Professor prof, Section section)
        {
            if (prof.scheduler(section) == true)
            {
                if (professor == null)
                {
                    addProfessor(prof, section);
                    return true;
                }
                else
                {
                    professor.removeSection(section);
                    professor.unCacheSection(section);
                    addProfessor(prof, section);
                    return true;
                }
            }

            return false;
        }

        public string getProfessorFullName()
        {
            if (professor != null) return professor.Name;

            return "Staff";
        }

        public string getCourseName()
        {
            return course.Name;
        }

        public int getUnits()
        {
            return course.Units;
        }

        public string getDay()
        {
            var secDay = new System.Text.StringBuilder();

            foreach (string day in classDays)
            {
                secDay.AppendLine(day.ToString());
            }
            return secDay.ToString();
        }
        public string getTime()
        {

            DateTime st = DateTime.ParseExact(startTime.ToString(), "HHmm", null, DateTimeStyles.None);
            st.ToString("HH:mm tt");
            DateTime et = DateTime.ParseExact(endTime.ToString(), "HHmm", null, DateTimeStyles.None);
            return st.ToString("HH:mm tt") + " - " + et.ToString("HH:mm tt");
        }
    }
}

