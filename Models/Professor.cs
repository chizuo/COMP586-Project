namespace Registration.Models
{
    public class Professor : Person
    {
        List<Section> cachedSections;

        public Professor(int id, string first, string last, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, string zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middle = "", string email = "", string areaCode = "", string phone = "", List<Section>? cachedSections = null)
         : base(id, first, last, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middle, email, areaCode, phone)
        {
            this.cachedSections = cachedSections != null ? cachedSections : new List<Section>();
        }

        public void cacheSection(Section section)
        {
            cachedSections.Add(section);
        }

        public void unCacheSection(Section section)
        {
            //cachedSections.Remove(section.sectionNumber.ToString());
        }
    }
}