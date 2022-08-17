namespace CertificatesDataGenerator.Extensions
{
    public static class CertificateExtensions
    {
        public static string GetInstituite(this string str, string value = "\\")
        {
            int index = str.LastIndexOf(value);
            return index >= 0 ? str[(index + value.Length)..] : str;
        }

        public static string GetWorkload(this string str, string extension = ".pdf")
        {
            return str.Replace(extension, string.Empty);
        }
    }
}
