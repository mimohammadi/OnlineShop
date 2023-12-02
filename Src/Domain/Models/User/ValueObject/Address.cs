namespace Domain.Models.User.ValueObject
{
    public record Address
    {
        public string FullAddress { get; private set; }
        public string PostalCode { get; private set; }

        protected Address()
        {  
        }

        public Address(string fullName, string postalCode)
        {
            FullAddress = fullName;
            PostalCode = postalCode;
        }
    }
}
