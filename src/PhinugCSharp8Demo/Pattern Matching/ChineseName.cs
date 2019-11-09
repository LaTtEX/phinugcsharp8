namespace PhinugCSharp8Demo.Pattern_Matching
{
    public class ChineseName : Name
    {
        public ChineseName(string familyName, string firstName, string secondName)
            : base(firstName, secondName, fathersSurname: familyName)
        {
            
        }        
    }
}