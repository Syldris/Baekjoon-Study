#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 22);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        string[] input = sr.ReadLine().Split();
        int level = int.Parse(input[0]);

        sw.Write(level * score(input[1]));

        int score(string text) => text switch
        {
            "miss" => 0,
            "bad" => 200,
            "cool" => 400,
            "great" => 600,
            "perfect" => 1000,
        };
    }
}