namespace Common.Converter.String
{
    public static class StringUtility
    {
        public static bool IsNullOrEmptyOrWhiteSpace(string fieldName)
        {
            if (fieldName is null || string.IsNullOrEmpty(fieldName.Trim()) || fieldName == "")
                return true;
            return false;
        }
    }
}
