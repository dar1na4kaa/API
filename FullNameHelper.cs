using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamModule4
{
    public static class FullNameHelper
    {
        public static bool IsCorrect(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return false;

            string pattern = @"^[А-Яа-яЁё\s\-]+$";
            string[] parts = fullName.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            return parts.All(part => Regex.IsMatch(part, pattern));
        }

        public static string Convert(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            string allowedPattern = @"[^А-Яа-яЁё\s\-]";

            string cleaned = Regex.Replace(fullName, allowedPattern, "");

            return cleaned.Trim();
        }

    }
}
