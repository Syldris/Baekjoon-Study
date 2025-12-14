#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int result = 0;
        int value = 0;

        for (int i = 0; i < 10; i++)
        {
            int n = int.Parse(sr.ReadLine());
            value += n;
            if(Math.Abs(100-value) <= Math.Abs(100-result))
            {
                result = value;
            }
        }
        sw.WriteLine(result);
    }
}