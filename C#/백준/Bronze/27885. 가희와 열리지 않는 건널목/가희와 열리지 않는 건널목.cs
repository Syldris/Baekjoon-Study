#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int c = int.Parse(input[0]);
        int h = int.Parse(input[1]);

        int[] time = new int[c + h];
        for (int i = 0; i < c + h; i++)
        {
            string[] line = sr.ReadLine().Split(':');
            int hour = int.Parse(line[0]);
            int min = int.Parse(line[1]);
            int sec = int.Parse(line[2]);
            time[i] = hour * 3600 + min * 60 + sec;
        }
        Array.Sort(time);
        int value = 3600 * 24 - 40;
        for (int i = 1; i < c + h; i++)
        {
            if (time[i - 1] + 40 > time[i])
            {
                value += time[i - 1] + 40 - time[i];
            }
            value -= 40;
        }

        sw.Write(value);
    }
}