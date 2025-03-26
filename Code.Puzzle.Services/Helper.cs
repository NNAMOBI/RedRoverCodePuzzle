using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Puzzle.Services
{
    public static class Helper
    {

        public static List<Field> Parse(string input)
        {
            int i = 0;
            return ParseFields(input, ref i);
        }

        public static List<Field> ParseFields(string input, ref int i)
        {
            var fields = new List<Field>();
            string buffer = "";

            while (i < input.Length)
            {
                char c = input[i];

                if (c == '(')
                {
                    var parent = buffer.Trim();
                    i++; // skip '('

                    var children = ParseFields(input, ref i);
                    fields.Add(new Field { Name = parent, Children = children });
                    buffer = "";
                }
                else if (c == ')')
                {
                    if (!string.IsNullOrWhiteSpace(buffer))
                        fields.Add(new Field { Name = buffer.Trim() });
                    i++; // skip ')'

                    return fields;
                }
                else if (c == ',')
                {
                    if (!string.IsNullOrWhiteSpace(buffer))
                        fields.Add(new Field { Name = buffer.Trim() });
                    buffer = "";
                    i++;
                }
                else
                {
                    buffer += c;
                    i++;
                }
            }

            return fields;
        }



        public static void PrintFirstOutput(List<Field> fields, int indent = 0)
        {
            foreach (var field in fields)
            {
                Console.WriteLine($"{new string(' ', indent * 2)}- {field.Name}");
                if (field.Children.Count > 0)
                    PrintFirstOutput(field.Children, indent + 1);
            }
        }

        public static void PrintSecondOutput(List<Field> fields)
        {
            foreach (var field in fields.OrderBy(f => f.Name))
            {
                Console.WriteLine("- " + field.Name);
                if (field.Children.Any())
                    PrintStructuredRecursive(field.Children, 1);
            }
        }

        private static void PrintStructuredRecursive(List<Field> fields, int indent)
        {
            foreach (var field in fields.OrderBy(f => f.Name))
            {
                Console.WriteLine($"{new string(' ', indent * 2)}- {field.Name}");
                if (field.Children.Any())
                    PrintStructuredRecursive(field.Children, indent + 1);
            }
        }
    }
}
