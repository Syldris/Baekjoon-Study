#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(sr.ReadLine()) - 1;
                arr[i] = num;
            }

            int value = 0;
            int target = 0;
            while (target != n - 1 && value < n)
            {
                target = arr[target];
                value++;
            }

            sw.WriteLine(value == n ? 0 : value);
        }
    }
}