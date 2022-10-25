namespace Registration.Models
{
    public abstract class Person
    {
        protected int Id { get; set; }
        protected string firstName { get; set; }
        protected string middleName { get; set; }
        protected string lastName { get; set; }
        protected string gender { get; set; }
        protected int birthMonth { get; set; }
        protected int birthDay { get; set; }
        protected int birthYear { get; set; }
        protected string email { get; set; }
        protected string areaCode { get; set; }
        protected string phoneNumber { get; set; }
        protected string address { get; set; }
        protected string city { get; set; }
        protected string state { get; set; }
        protected int zip { get; set; }
        protected string personType { get; set; }
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
    }
}