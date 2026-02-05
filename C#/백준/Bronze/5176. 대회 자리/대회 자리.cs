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
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            int result = 0;
            bool[] arr = new bool[k + 1];
            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(sr.ReadLine());
                if (!arr[value])
                {
                    arr[value] = true;
                }
                else
                {
                    result++;
                }
            }
            sw.WriteLine(result);
        }
    }
}