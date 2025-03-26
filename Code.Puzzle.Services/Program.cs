namespace Code.Puzzle.Services
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
            List<Field> result = Helper.Parse(input);
            Helper.PrintFirstOutput(result);


            Console.WriteLine("-----------------------------");

            Helper.PrintSecondOutput(result);
        }
    }
}
