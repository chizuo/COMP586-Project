
using System.Globalization;
namespace Registration.Models
{
    public class Professor : Person
    {
        public List<Section> cachedSections;

        public Professor(int id, string first, string last, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, string zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middle = "", string email = "", string areaCode = "", string phone = "", List<Section>? cachedSections = null)
         : base(id, first, last, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middle, email, areaCode, phone)
        {
            this.cachedSections = cachedSections != null ? cachedSections : new List<Section>();
        }

        public void cacheSection(Section section)
        {
            cachedSections.Add(section);
        }
        public string secName()
        {
            foreach (Section section in cachedSections)
            {
                return section.getCourseName();
            }
            return "No name";
        }
        public string secDay()
        {
            var secDay = new System.Text.StringBuilder();
            foreach (Section section in cachedSections)
            {
                foreach (string day in section.classDays)
                {
                    secDay.AppendLine(day.ToString());
                }
                return secDay.ToString();
            }
            return "No Date/Time";
        }
        public string secTime()
        {
            foreach (Section section in cachedSections)
            {
                int startTime = section.startTime;
                DateTime st = DateTime.ParseExact(startTime.ToString(), "HHmm", null, DateTimeStyles.None);
                st.ToString("HH:mm tt");
                int endTime = section.endTime;
                DateTime et = DateTime.ParseExact(endTime.ToString(), "HHmm", null, DateTimeStyles.None);
                return st.ToString("HH:mm tt") + " - " + et.ToString("HH:mm tt");
            }

            return "0";
        }
        public string secLocation()
        {
            foreach (Section section in cachedSections)
            {
                return section.classLocation;
            }
            return "No Loc";
        }
        public string date()
        {
            foreach (Section section in cachedSections)
            {
                return section.startDate.ToShortDateString();
            }
            return "";
        }

        public void unCacheSection(Section section)
        {
            //cachedSections.Remove(section.sectionNumber.ToString());
        }
    }
}