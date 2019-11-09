namespace PhinugCSharp8Demo.Pattern_Matching
{
    public class AmericanName : Name
    {
        public AmericanName(string firstName, string familyName, 
            string secondName = null)
            : base(firstName, secondName, fathersSurname: familyName)
        {
            
        }
    }
}