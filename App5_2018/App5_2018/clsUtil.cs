namespace App5_2018
{
    static class clsUtil
    {
        public static string EmptyIfNull(this string prString)
        {
            return prString == null ? string.Empty : prString;
        }
    }
}
