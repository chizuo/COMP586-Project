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

        protected Dictionary<string, List<Section>> schedule;

        // Constructor with optional arguments
        public Person(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "")
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
            var days = section.classDays;
            foreach (string day in days)
            {
                List<Section> dailySchedule = schedule[day];
                dailySchedule.Add(section);
            }
        }

        public void removeSection(Section section)
        {
            var days = section.classDays;
            foreach (string day in days)
            {
                List<Section> dailySchedule = schedule[day];
                dailySchedule.Remove(section);
            }

        }


        public abstract Boolean availability(Section section);
    }
}