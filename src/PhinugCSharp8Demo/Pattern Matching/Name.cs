namespace PhinugCSharp8Demo.Pattern_Matching
{
    public abstract class Name
    {
        public Name(string name, 
            string secondName = null, 
            string mothersSurname = null, 
            string fathersSurname = null)
        {
            FirstName = name.Trim();
            SecondName = secondName?.Trim();
            MothersSurname = mothersSurname?.Trim();
            FathersSurname = fathersSurname?.Trim();
        }

        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public string MothersSurname { get; protected set; }
        public string FathersSurname { get; protected set; }
    }
}