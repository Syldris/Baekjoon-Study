#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int[] time = new int[1001];
        int result = 0;

        for (int i = 0; i < n; i++)
        {
            int pos = int.Parse(sr.ReadLine());
            int value = 0;

            for (int j = 1; j < pos; j++)
            {
                value = Math.Max(value, time[j]) + 1;

                if (time[j + 1] > value)
                {
                    value = time[j + 1];
                    time[j] = value;
                }
                else
                {
                    time[j] = value;
                }
            }

            time[pos] = Math.Max(value, time[pos]) + 5;
            result = Math.Max(result, time[pos]);
        }

        sw.Write(result);
    }
}