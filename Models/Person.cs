namespace Registration.Models
{
    public abstract class Person
    {
        protected int id;
        public int ID { get { return id; } }
        protected string first;
        protected string middle;
        protected string last;
        public string Name { get { return middle.Length > 0 ? $"{first} {middle} {last}" : $"{first} {last}"; } }
        protected string gender;
        public string Gender { get { return gender; } }
        protected int birthMonth;
        protected int birthDay;
        protected int birthYear;
        public string Birthday { get { return $"{birthMonth}/{birthDay}/{birthYear}"; } }
        protected string email;
        public string Email { get { return email; } }
        protected string areaCode;
        protected string phone;
        public string Phone { get { return $"({areaCode}){phone}"; } }
        protected string address;
        protected string city;
        protected string state;
        protected string zip;
        public string Address { get { return $"{address}, {city} {state} {zip}"; } }
        protected string personType;
        public string Type { get { return personType; } }
        protected Dictionary<string, List<Section>> schedule;

        // Constructor with optional arguments
        public Person(int id, string first, string last, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, string zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middle = "", string email = "", string areaCode = "", string phone = "")
        {
            this.id = id;
            this.first = first;
            this.middle = middle;
            this.last = last;
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
            this.phone = phone;
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

        public void updateInfo(string middle = "", string email = "", string areaCode = "", string phone = "", string address = "", string city = "", string state = "", string zip = "")
        {
            this.middle = middle.Length > 0 ? middle : this.middle;
            this.email = email.Length > 0 ? email : this.email;
            this.areaCode = areaCode.Length > 0 ? areaCode : this.areaCode;
            this.phone = phone.Length > 0 ? phone : this.phone;
            this.address = address.Length > 0 ? address : this.address;
            this.city = city.Length > 0 ? city : this.city;
            this.state = state.Length > 0 ? state : this.state;
            this.zip = zip.Length > 0 ? zip : this.zip;
        }
    }
}