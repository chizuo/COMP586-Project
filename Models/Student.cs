namespace Registration.Models
{
    public class Student : Person
    {

        //key: course name, value: credits, grade
        Dictionary<string, Tuple<int, float>> courses { get; set; };

        public void calculateGPA()
        {

        }
    }