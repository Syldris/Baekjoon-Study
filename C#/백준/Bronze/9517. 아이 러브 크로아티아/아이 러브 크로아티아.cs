#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int k = int.Parse(sr.ReadLine());
        int n = int.Parse(sr.ReadLine());

        int time = 0;
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            time += int.Parse(line[0]);

            if (time >= 210)
            {
                sw.Write(k);
                return;
            }
            if (line[1] == "T")
            {
                k = k == 8 ? 1 : k + 1; 
            }
        }
        sw.Write(k);
    }
}