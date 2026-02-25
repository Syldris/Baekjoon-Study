#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        HashSet<string> hash = new();
        for (int i = 0; i < n; i++)
        {
            hash.Add(sr.ReadLine());
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split(',');
            foreach (string text in line)
            {
                if (hash.Contains(text))
                {
                    hash.Remove(text);
                }
            }
            sw.WriteLine(hash.Count);
        }
    }
}