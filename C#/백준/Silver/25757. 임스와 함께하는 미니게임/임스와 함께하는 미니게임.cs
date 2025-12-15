#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int game = input[1] == "Y" ? 1 : input[1] == "F" ? 2 : 3;

        HashSet<string> people = new HashSet<string>();
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            people.Add(line);
        }
        int result = people.Count / game;
        sw.Write(result);
    }
}