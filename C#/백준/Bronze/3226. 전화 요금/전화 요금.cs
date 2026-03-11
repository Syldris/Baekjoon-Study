#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split();
            string[] time = input[0].Split(':');

            int d = int.Parse(input[1]);
            int hour = int.Parse(time[0]);
            int min = int.Parse(time[1]);

            if (hour >= 7 && hour < 19)
            {
                if (hour == 18)
                {
                    int k = Math.Min(60 - min, d);
                    result += 10 * k; 
                    d -= k;

                    result += 5 * d;
                }
                else
                    result += 10 * d;
            }
            else
            {
                if (hour == 6)
                {
                    int k = Math.Min(60 - min, d);
                    result += 5 * k;
                    d -= k;

                    result += 10 * d;
                }
                else
                    result += 5 * d;
            }
        }

        sw.Write(result);
    }
}