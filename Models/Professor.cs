namespace Registration.Models
{
    public class Professor : Person
    {
        public Professor(string firstName, string lastName, string gender, int birthMonth, int birthDay, int birthYear, string address, string city, string state, int zip, string personType, Dictionary<string, List<Section>>? schedule = null, string middleName = "", string email = "", string areaCode = "", string phoneNumber = "")
         : base(firstName, lastName, gender, birthMonth, birthDay, birthYear, address, city, state, zip, personType, schedule = null, middleName = "", email = "", areaCode = "", phoneNumber = "")
        {
        }
        public Boolean removeSection(Section section){
           int functionCheck=0; //incremented each time a section is removed 
           int sectionCode = section.classSectionNumber; //retrieving the section's section number 
           string [] daysOfOperation = section.classDays; //retrieving the days for sections
            
            foreach(string courseDay in daysOfOperation){ //for each day that the section occurs
                List<Section> dailySchedule = schedule[courseDay]; //retrieving the scheduled days the section occurs on
                int index = 0;
                foreach(Section sections in dailySchedule){ //iterating through the persons schedule of sections in each day that contains the section that needs to be removed
  
                    if(sections.classSectionNumber==sectionCode){ //if that day contains the section number we want -> remove it, otherwise break, and check the next day (index)
                        dailySchedule.RemoveAt(index); 
                        functionCheck++;
                        break;
                    }
                    index++;
                }
            }
            if(functionCheck==daysOfOperation.Length){return true;} //when the functionChecker is equal to the number of sections removed -> 
                                                                    //return true, ensuring successful removal of the section passed 
            return false; //this function should never return false
        }
    }
}