using PhoneNumbers;

namespace Common.Help
{
    public static class Validator
    {
        public static bool IsValidNumber(string aNumber)
        {
            aNumber = aNumber.Trim();

            if (aNumber.StartsWith("00") || aNumber.StartsWith("+"))
            {
                // Replace 00 at beginning with +
                //aNumber = "+" + aNumber.Remove(0, 2);
                return false;
            }

            try
            {
                var phoneUtil = PhoneNumberUtil.GetInstance();
                var numberProto = phoneUtil.Parse(aNumber, "IR");
                return phoneUtil.IsValidNumber(numberProto); // to iran
            }
            catch
            {
                return false;
            }
        }
    }
}
