namespace PhinugCSharp8Demo
{
    public class Customer
    {
        public Customer(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; set; }
    }
}