using System.Text.RegularExpressions;

namespace Thera.Talent.Management.Web.Common
{
    public static class Utils
    {
        private static Regex Regex = new Regex(@"(\.[^.\/]+)$");

        public static string GetExtension(string path)
        {
            Match match = Regex.Match(path);

            foreach (Group entry in match.Groups)
                return entry.Value;

            return "";
        }
    }
}