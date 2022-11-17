namespace Registration.Models
{
    public abstract class Person
    {
        protected int Id;
        protected string firstName;
        protected string middleName;
        protected string lastName;
        protected string gender;
        protected int birthMonth;
        protected int birthDay;
        protected int birthYear;
        protected string email;
        protected string areaCode;
        protected string phoneNumber;
        protected string address;
        protected string city;
        protected string state;
        protected int zip;
        protected string personType;
        protected Dictionary<string, List<Section>> schedule;

        // Constructor with optional arguments
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "")
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.personType = personType;
            this.email = email;
            this.areaCode = areaCode;
            this.phoneNumber = phoneNumber;
            this.schedule = schedule != null ? schedule : new Dictionary<string, List<Section>> {
                                                            { "M", new List<Section>() },
                                                            { "T", new List<Section>() },
                                                            { "W", new List<Section>() },
                                                            { "Th", new List<Section>() },
                                                            { "F", new List<Section>() },
                                                            { "Sa", new List<Section>() }
                                                        };
        }

        public void addSection(Section section)
        {
            foreach (string day in section.classDays)
            {
                List<Section> dailySchedule = schedule[day];
                dailySchedule.Add(section);
            }
        }

        public Boolean removeSection(Section section)
        {
            int functionCheck = 0; //incremented each time a section is removed 
            string[] daysOfOperation = section.classDays; //retrieving the days for sections

            foreach (string courseDay in daysOfOperation)
            { //for each day that the section occurs
                List<Section> dailySchedule = schedule[courseDay]; //retrieves the list that represent's courseDay's schedule of Sections.
                int index = 0;
                foreach (Section sections in dailySchedule)
                { //iterating through the List of Sections for the Person's dailySchedule

                    if (sections.sectionNumber == section.sectionNumber)
                    { //if that section contains the sectionNumber we want -> remove it and break out of the current dailySchedule, and check the next day (index)
                        dailySchedule.RemoveAt(index);
                        functionCheck++;
                        break;
                    }
                    index++;
                }
            }
            if (functionCheck == daysOfOperation.Length) { return true; } //when the functionChecker is equal to the number of sections removed -> 
                                                                          //return true, ensuring successful removal of the section passed 
            return false; //this function should never return false
        }

        public Boolean scheduler(Section section)
        {
            var scheduler = new List<List<Section>>();

            /* gets each daily schedule List<Section> for the days of the section */
            foreach (string day in section.classDays)
            {
                scheduler.Add(this.schedule[day]);
            }

            /* runs through the schedule of the day */
            foreach (var dailySchedule in scheduler)
            {
                /* if any of the sections already in the schedule conflicts with the section being added, return false */
                foreach (var sectionInSchedule in dailySchedule)
                {
                    /* section.startTime exists within the sectionInSchedule's start & end time; section & sectionInSchedule */
                    if (sectionInSchedule.startTime <= section.startTime && sectionInSchedule.endTime >= section.startTime)
                        return false;

                    /* section.endTime exists within the sectionInSchedule's start & end time; section & sectionInSchedule */
                    if (sectionInSchedule.startTime <= section.endTime && sectionInSchedule.endTime >= section.endTime)
                        return false;

                    /* sectionInSchedule is scheduled in between the section attempting to be added; sectionInSchedule is a proper subset of section */
                    if (section.startTime <= sectionInSchedule.startTime && section.endTime >= sectionInSchedule.endTime)
                        return false;

                    /* section that is being added exists in the time frame between sectionInSchedule; section is a proper subset of sectionInSchedule */
                    if (sectionInSchedule.startTime <= section.startTime && sectionInSchedule.endTime >= section.endTime)
                        return false;
                }
            }

            return true;
        }

        public List<string> coursesInSchedule()
        {
            var courseList = new List<string>();
            var week = new List<string>() { "M", "T", "W", "Th", "F", "Sa" };

            foreach (var day in week)
            {
                foreach (var section in schedule[day])
                {
                    courseList.Add(section.getCourseName());
                }
            }

            return courseList;
        }

        public string getName()
        {
            if (middleName != "") return firstName + " " + middleName + " " + lastName;

            return firstName + " " + lastName;
        }

        public int getId()
        {
            return Id;
        }

        public string getAddress(){
            return address+" "+city+", "+state+", "+zip;
        }

        public string getPhoneNumber(){
         string firstThree = phoneNumber.Substring(0, 2);
         string lastFour = phoneNumber.Substring(3,3);
            return "("+ areaCode +")"+ "-" +firstThree+lastFour;
        }

        public string getEmail(){
            return email;
        }
    }
}