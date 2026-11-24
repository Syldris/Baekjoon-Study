#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        const long RANGE = 1000000000000000000; // 10^18

        long min = -RANGE;
        long max = RANGE;

        int order = -1;

        for (int i = 1; i <= n; i++)
        {
            string[] split = sr.ReadLine().Split();

            long number = long.Parse(split[0]);
            string upDown = split[1];

            if (upDown == "^") // number 업이니까 number+1 이상.
                min = Math.Max(number + 1, min);
            else               // number 다운이니까 number -1 이하.
                max = Math.Min(number - 1, max);

            if (min == max && order == -1) // 처음으로 번호를 정확히 알아내면.
            {
                order = i;
            }

            if (min > max || min < -RANGE || max > RANGE) // 모순체크. min > max 거나 둘중하나 10^18 범위 초과.
            {
                sw.WriteLine("Paradox!");
                sw.WriteLine(i);
                return;
            }

        }

        if(order != -1)
        {
            sw.WriteLine("I got it!");
            sw.WriteLine(order);
            return;
        }

        sw.Write("Hmm...");
    }
}