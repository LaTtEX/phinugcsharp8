namespace PhinugCSharp8Demo.Pattern_Matching
{
    public class SpanishName : Name
    {
        public SpanishName(string firstName, 
            string secondName, 
            string fathersSurname,
            string mothersSurname)
            : base(firstName, secondName, mothersSurname, fathersSurname)
        {

        }
    }
}