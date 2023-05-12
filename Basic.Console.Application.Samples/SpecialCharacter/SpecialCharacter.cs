using System.Text.RegularExpressions;

namespace Basic.Console.Application.Samples.SpecialCharacter
{
    public static class SpecialCharacter
    {
        public static bool ValidateInputData(string input)
        {
            bool result = false;

            if (input == null || input.Length == 0)
                result = false;
            //var count = 0;

            var isCommandArray = Regex.IsMatch(input, @"^\({[.*?\)}]$");

            //char[] openBraces = new char[3] { '(', '{', '[' };
            //char[] closeBraces = new char[3] { ')', '}', ']' };

            var pairs = new List<Tuple<char, char>>
            {
                new Tuple<char, char>('(', ')'),
                new Tuple<char, char>('{', '}'),
                new Tuple<char, char>('[', ']'),
            };

            var openTags = new HashSet<char>();
            var closeTags = new HashSet<char>();
            //var closeTags = new Dictionary<char, char>(pairs.Count);
            foreach (var p in pairs)
            {
                openTags.Add(p.Item1);
                closeTags.Add(p.Item2);
                // closeTags.Add(p.Item2, p.Item1);
            }

            // Remove quoted parts
            Regex r = new Regex("\".*?\"", RegexOptions.Compiled | RegexOptions.Multiline);
            input = r.Replace(input, string.Empty);

            int count = 0;
            var opened = new Stack<char>();
            foreach (var ch in input)
            {
                if (ch == '"')
                {
                    // Unpaired quote char
                    result = false;
                }
                if (openTags.Contains(ch))
                {
                    // This is a legal open tag
                    opened.Push(ch);
                    count++;
                }
                else if (closeTags.Contains(ch))
                {
                    // This is a legal open tag
                    opened.Push(ch);
                    count--;
                }
                //else if (closeTags.TryGetValue(ch, out var openTag) && openTag != opened.Pop())
                //{
                //    // This is an illegal close tag or an unbalanced legal close tag
                //    result = false;
                //}
            }
            //if (count == 0)
            //    result = true;


            return isCommandArray;
        }

        public static bool IsValidString(string s)
        {
            Stack<char> ch = new Stack<char>();
            foreach (var item in s.ToCharArray())
                if (item == '(')
                    ch.Push(')');
                //else if (item == ')')
                //    ch.Push('(');
                else if (item == '<')
                    ch.Push('>');
                //else if (item == '>')
                //    ch.Push('<');
                else if (item == '[')
                    ch.Push(']');
                //else if (item == ']')
                //    ch.Push('[');
                else if (item == '{')
                    ch.Push('}');
                //else if (item == '}')
                //    ch.Push('{');
                else if (ch.Count == 0 || ch.Pop() != item)
                    return false;

            return ch.Count == 0;
        }

        public static bool IsValidStringWithReplaceFunction(string text)
        {
            string temp_text = string.Empty;

            while (text != temp_text)
            {
                temp_text = text;
                text = text.Replace("<>", "").Replace("()", "").Replace("[]", "").Replace("{}", "");
            }

            return text == string.Empty ? true : false;
        }
    }
}
