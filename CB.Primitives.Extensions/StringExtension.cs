using System;
using System.Text.RegularExpressions;


namespace CB.Primitives.Extensions
{
    public static class StringExtension
    {
        #region Methods
        public static TextType GetTextType(this string text) { }

        public static string Normalize(this string text, TextType type = TextType.Auto)
        {
            type = GetTextType(text, type);
            switch (type)
            {
                case TextType.Normal:
                    return text;
                case TextType.Underscored:
                    return text.NormalizeUnderscoredText();
                case TextType.LowerCamelCase:
                    return text.NormalizeLowerCamelCaseText();
                case TextType.Pascalized:
                    return text.NormalizePascalizedText();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string NormalizeLowerCamelCaseText(this string text)
        {
            return text.RegexReplace(@"\b\w", m => m.Value.ToUpper()).NormalizePascalizedText();
        }

        public static string Pascalize(this string text, TextType type = TextType.Auto)
        {
            type = GetTextType(text, type);
            switch (type)
            {
                case TextType.Normal:
                    return text.PascalizeNormalText();
                case TextType.Underscored:
                    return text.PascalizeUnderscoredText();
                case TextType.LowerCamelCase:
                    return text.PascalizeLowerCamelCaseText();
                case TextType.Pascalized:
                    return text;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string PascalizeLowerCamelCaseText(this string text)
            => text.RegexReplace(@"\b\w", m => m.Value.ToUpper());

        public static string PascalizeNormalText(this string text)
            => text.RegexReplace(@"[\b\s](\w)", m => m.Groups[1].Value.ToUpper());

        public static string PascalizeUnderscoredText(this string text)
            => text.RegexReplace(@"[\b_](\w)", m => m.Groups[1].Value.ToUpper());

        public static string RegexReplace(this string input, string pattern, string replacement)
            => Regex.Replace(input, pattern, replacement);

        public static string RegexReplace(this string input, string pattern, string replacement, RegexOptions options)
            => Regex.Replace(input, pattern, replacement, options);

        public static string RegexReplace(this string input, string pattern, string replacement, RegexOptions options,
            TimeSpan matchTimeout) => Regex.Replace(input, pattern, replacement, options, matchTimeout);

        public static string RegexReplace(this string input, string pattern, MatchEvaluator evaluator)
            => Regex.Replace(input, pattern, evaluator);

        public static string RegexReplace(this string input, string pattern, MatchEvaluator evaluator,
            RegexOptions options) => Regex.Replace(input, pattern, evaluator, options);

        public static string RegexReplace(this string input, string pattern, MatchEvaluator evaluator,
            RegexOptions options, TimeSpan matchTimeout)
            => Regex.Replace(input, pattern, evaluator, options, matchTimeout);
        #endregion


        #region Implementation
        private static TextType GetTextType(string text, TextType type)
            => type == TextType.Auto ? GetTextType(text) : type;

        private static string NormalizePascalizedText(this string text)
            => text.RegexReplace(@"(?=[a-z])[A-Z]", m => $" {m.Value}");

        private static string NormalizeUnderscoredText(this string text)
            => text.RegexReplace(@"_\w", m => $" {m.Value.ToUpper()}");
        #endregion
    }

    public enum TextType
    {
        Auto,
        Normal,
        Underscored,
        LowerCamelCase,
        Pascalized
    }
}