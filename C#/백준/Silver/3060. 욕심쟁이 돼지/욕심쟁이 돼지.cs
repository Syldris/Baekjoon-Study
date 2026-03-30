#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int day = 1;

            while (true)
            {
                long need = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    need += arr[i];
                }

                if (need > n)
                {
                    sw.WriteLine(day);
                    break;
                }

                day++;

                int[] add = new int[6];

                for (int i = 0; i < 6; i++)
                {
                    add[i] = arr[(i + 1) % 6] + arr[(i + 5) % 6] + arr[(i + 3) % 6];
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] += add[i];
                }
            }
        }
    }
}