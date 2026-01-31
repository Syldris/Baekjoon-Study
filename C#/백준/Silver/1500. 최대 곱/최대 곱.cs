#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int s = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        long result = 1;
        int mod = s % k;
        for (int i = 0; i < k; i++)
        {
            int value = s / k;

            if (mod > 0)
            {
                value++;
                mod--;
            }

            result *= value;
        }

        sw.Write(result);
    }
}