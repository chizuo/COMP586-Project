namespace Registration.Models
{
    public class Department
    {
        protected string name;
        public string Name { get { return name; } }
        protected string code;
        public string Code { get { return code; } }
        protected Professor? professor;
        public Professor Chair { get { return professor; } set { professor = value; } }

        public Department(string name, string code, Professor? professor = null)
        {
            this.name = name;
            this.code = code;
            this.professor = professor;
        }
    }
}