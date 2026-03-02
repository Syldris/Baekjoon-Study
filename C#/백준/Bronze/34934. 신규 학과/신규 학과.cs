#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            if (line[1] == "2026")
            {
                sw.Write(line[0]);
                return;
            }    
        }
    }
}