namespace Registration.Models
{
    public class Professor : Person
    {
        Dictionary<string, Section> cachedSections;

        public Professor(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "", Dictionary<string, Section>? cachedSections = null)
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = "")
        {
            this.cachedSections = cachedSections != null ? cachedSections : new Dictionary<string, Section>();
        }

        public void cacheSection(Section section)
        {
            cachedSections.Add(section.sectionNumber.ToString(), section);
        }

        public void unCacheSection(Section section)
        {
            cachedSections.Remove(section.sectionNumber.ToString());
        }
    }
}