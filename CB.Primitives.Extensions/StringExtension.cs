using System;
using System.Text.RegularExpressions;


namespace CB.Primitives.Extensions
{
    public static class StringExtension
    {
        #region Methods
        public static string Replace(string input, string pattern, string replacement)
            => Regex.Replace(input, pattern, replacement);

        public static string Replace(string input, string pattern, string replacement, RegexOptions options)
            => Regex.Replace(input, pattern, replacement, options);

        public static string Replace(string input, string pattern, string replacement, RegexOptions options,
            TimeSpan matchTimeout)
            => Regex.Replace(input, pattern, replacement, options, matchTimeout);

        public static string Replace(string input, string pattern, MatchEvaluator evaluator)
            => Regex.Replace(input, pattern, evaluator);

        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options)
            => Regex.Replace(input, pattern, evaluator, options);

        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options,
            TimeSpan matchTimeout)
            => Regex.Replace(input, pattern, evaluator, options, matchTimeout);
        #endregion
    }
}