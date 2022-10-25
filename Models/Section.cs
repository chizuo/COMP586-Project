namespace Registration.Models
{

    public class Section
    {

        /*
        Course : Course Object
        Professor : Professor Object
        Section : int
        Term : string
        Year : int
        SectionNo : int
        Students : List of ints
        MaxSeats : int
        */
        //Course courseObject = new Course();
        //Professor professorObject = new Professer();

        /*
        Class Information:
        Class ID Number: int
        Class Section: int
        School Year : int
        School Term : string 
        */

        public int classIdNumber;
        public int classSectionNumber;
        public int schoolYear;
        public string schoolTerm;

        /*
        Class Availability:
        Enrollment Capacity: int
        Enrollment Total: int
        Wait List Capacity: int
        Wait List Total: int
        */

        public int enrollmentCap;
        public int enrollmentTotal;
        public int waitListcap;
        public int waitListTotal;

        /*
        Meeting Infomation:
        Class Days: []string Mon 0, Tue 1, Wed 2, Thur 3, Friday 4, Sat 5
        Class Time: string or DateTime object
        
        Start times and End times are going to be represent in a military format. 
        7:00 in the afternoon is going to be represented as 19:00.
        9:00 in the even is going to be represented as 21:00.
        1:00 in the after is going to be represented as 13:00.
        7:00 in the morning is going to be represented as 7:00.

        Start Time: int
        End Time: int 
        
        Class Location: string / hyperlink
        Class Meeting Dates : string / DateTime Object 
        */

        public string[] classDays;
        public int startTime;

        public int endTime;
        public string classLocation;
        public string classMeetingDates;


        /*
        Notes:
        Class Note : string
        */
        public string classNote;

        // Still waiting on the students class
        //public List<students> studentsList;

        /*
        Add Numbers: Dictionary<int, string>
        */

        public Dictionary<int, string> addNumbers = new Dictionary<int, string>();


        public Section(int classIdNumber, int classSectionNumber, string schoolTerm, int schoolYear, int enrollmentCap, int enrollmentTotal, int waitListcap, int waitListTotal, string[] classDays, int startTime, int endTime, string classLocation, string classMeetingDates, string classNote, Dictionary<int, string> addNumbers)
        {
            this.classIdNumber = classIdNumber;
            this.classSectionNumber = classSectionNumber;

            this.schoolTerm = schoolTerm;
            this.schoolYear = schoolYear;

            this.enrollmentCap = enrollmentCap;
            this.enrollmentTotal = enrollmentTotal;
            this.waitListcap = waitListcap;
            this.waitListTotal = waitListTotal;

            this.classDays = classDays;
            this.startTime = startTime;
            this.endTime = endTime;
            this.classLocation = classLocation;
            this.classMeetingDates = classMeetingDates;

            this.classNote = classNote;

            this.addNumbers = addNumbers;
        }

        public int generateAddNumber()
        {
            Random rand = new Random();
            int addnumber;
            bool keyExists;

            do
            {
                addnumber = rand.Next(10000, 99999);
                keyExists = addNumbers.ContainsKey(addnumber);
            } while (keyExists);

            addNumbers.Add(addnumber, null);

            return addnumber;
        }
    }
}
