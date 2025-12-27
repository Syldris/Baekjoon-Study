#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string name = sr.ReadLine();
            int score = 0;
            foreach (var item in name)
            {
                if (item == ' ')
                {
                    continue;
                }
                score += item - 'A' + 1;
            }
            sw.WriteLine(score == 100 ? "PERFECT LIFE" : score);
        }
    }
}