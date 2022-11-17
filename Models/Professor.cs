namespace Registration.Models
{
    public class Professor : Person
    {
        List<Section> cachedSections;

        public Professor(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "", List<Section>? cachedSections = null)
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = "")
        {
            this.cachedSections = cachedSections != null ? cachedSections : new List<Section>();
        }

        public void addSection(List<Section> sectionList){
            
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