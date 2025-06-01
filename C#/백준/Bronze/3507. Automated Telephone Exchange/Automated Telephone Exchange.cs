#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int count = 0;
        for (int i = 1; i <= 99; i++)
        {
            for (int j = 1; j <= 99; j++)
            {
                if(n-i-j == 0)
                    count++;
            }
        }
        sw.Write(count);
    }
}