#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        Dictionary<string, int> dict = new();

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split('.');

            if (!dict.ContainsKey(line[1]))
                dict.Add(line[1], 1);

            else
                dict[line[1]]++;
        }

        List<(string name, int value)> list = new();
        foreach (var item in dict)
        {
            list.Add((item.Key, item.Value));
        }
        list.Sort();

        foreach ((string name, int value) in list)
        {
            sw.WriteLine($"{name} {value}");
        }
    }
}