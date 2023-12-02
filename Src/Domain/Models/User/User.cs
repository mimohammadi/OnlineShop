using Common.Converter.String;
using Common.Help;
using Common.Interface;
using Domain.Models.User.ValueObject;

namespace Domain.Models.User
{
    public class User:BaseEntity, IAggregateRoot
    {
        public string CellPhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string FullName { get; private set; }
        public Address Address { get; private set; }

        public virtual ICollection<Order.Order> Orders { get; private set; }
        protected User()
        {
            
        }

        public User(string cellPhoneNumber, string password, string fullName, Address address)
        {
            GuardAgainstIfCellPhoneNumberIsEmptyOrSpace(cellPhoneNumber);
            GuardAgainstIfCellPhoneNumberIsInvalid(cellPhoneNumber);
            GuardAgainstIfPasswordIsEmptyOrSpace(password);
            CellPhoneNumber = cellPhoneNumber;
            Password = password;
            FullName = fullName;
            Address = address;
        }

        private static void GuardAgainstIfPasswordIsEmptyOrSpace(string password)
        {
            if (StringUtility.IsNullOrEmptyOrWhiteSpace(password))
                throw new ArgumentNullException("پسورد اجباری می باشد");
        }

        private static void GuardAgainstIfCellPhoneNumberIsInvalid(string cellPhoneNumber)
        {
            if (!Validator.IsValidNumber(cellPhoneNumber))
                throw new ArgumentException("شماره تلفن را به درستی وارد کنید");
        }

        private static void GuardAgainstIfCellPhoneNumberIsEmptyOrSpace(string cellPhoneNumber)
        {
            if (StringUtility.IsNullOrEmptyOrWhiteSpace(cellPhoneNumber))
                throw new ArgumentNullException("شماره تلفن همراه اجباری می باشد");
        }
    }
}
