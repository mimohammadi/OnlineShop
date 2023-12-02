using FluentAssertions;

namespace DomainUnitTests.Models.User
{
    public class UserUnitTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void should_not_create_when_cellPhoneNumber_is_empty_or_space(string cellPhoneNumber)
        {
            Assert.Throws<ArgumentNullException> (() =>
            {
                var user = new Domain.Models.User.User(cellPhoneNumber, "12345678", "Mina", new Domain.Models.User.ValueObject.Address("tehran","1234567890"));
            });
        }

        [Theory]
        [InlineData("0912")]
        [InlineData("87766666666")]
        [InlineData("094566666")]
        [InlineData("+91123456781")]
        public void should_not_create_when_cellPhoneNumber_is_invalid(string cellPhoneNumber)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var user = new Domain.Models.User.User(cellPhoneNumber, "12345678", "Mina", new Domain.Models.User.ValueObject.Address("tehran", "1234567890"));
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void should_not_create_when_password_is_empty_or_space(string password)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var user = new Domain.Models.User.User("09191877777", password, "Mina", new Domain.Models.User.ValueObject.Address("tehran", "1234567890"));
            });
        }

        [Fact]
        public void should_be_created_valid_user()
        {
            string cellPhone = "09197654321";
            string password = "123456";

            var user = new Domain.Models.User.User(cellPhone, password, "Mina", new Domain.Models.User.ValueObject.Address("tehran", "1234567890"));

            string expectedCellPhone = "09197654321";
            string expectedFullName = "123456";

            user.CellPhoneNumber.Should().Be(expectedCellPhone);
            user.Password.Should().Be(expectedFullName);
        }
    }
}
