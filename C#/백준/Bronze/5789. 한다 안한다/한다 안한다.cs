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
            string line = sr.ReadLine();
            int index = line.Length / 2;
            if (line[index] == line[index - 1])
                sw.WriteLine("Do-it");
            else
                sw.WriteLine("Do-it-Not");
        }
    }
}