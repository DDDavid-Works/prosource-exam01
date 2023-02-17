internal class Program
{
    static void Main(string[] args)
    {
        string testString = "{}";
        TestMatchingBrackets(testString);

        testString = "}{";
        TestMatchingBrackets(testString);

        testString = "{{}";
        TestMatchingBrackets(testString);

        testString = "";
        TestMatchingBrackets(testString);

        testString = "{abc...xyz}";
        TestMatchingBrackets(testString);

        testString = "{abc{xyz}";
        TestMatchingBrackets(testString);

        testString = "{abc{fgh}xyz}";
        TestMatchingBrackets(testString);

        Console.ReadLine();
    }

    static void TestMatchingBrackets(string input)
    {
        Console.WriteLine("Unit test for " + input + ": " + HasMatchingBrackets(input));
    }

    static bool HasMatchingBrackets(string input)
    {
        List<int> openings = new List<int>(), 
            closings = new List<int>();

        int inpLength = input.Length;
        for (int i = 0; i < inpLength; i++)
        {
            if (input[i] == '{')
            {
                openings.Add(i);
                for (int j = inpLength - 1; j > i; j--)
                {
                    char c2 = input[j];
                    if (c2 == '}' && !closings.Any(cl => cl == j))
                        closings.Add(j);
                }
            }
        }

        return openings.Count == closings.Count;
    }

}