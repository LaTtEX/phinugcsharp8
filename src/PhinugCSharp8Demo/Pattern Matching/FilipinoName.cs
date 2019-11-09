namespace PhinugCSharp8Demo.Pattern_Matching
{
    public class FilipinoName : Name
    {
        public FilipinoName(string firstName, string familyName, string mothersSurname = null, string secondName = null)
            : base(firstName, secondName, mothersSurname, familyName)
        {
            
        }
    }
}