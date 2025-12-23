#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int h = int.Parse(input[1]);

        int[] diff = new int[h];
        int[] arr = new int[h];
        for (int i = 1; i <= n; i++)
        {
            int size = int.Parse(sr.ReadLine());
            if (i % 2 == 0)
            {
                diff[0]++;
                diff[size]--;
            }
            else
            {
                diff[h - size]++;
            }
        }

        int value = 0;
        for (int i = 0; i < h; i++)
        {
            value += diff[i];
            arr[i] = value;
        }

        int result = 200000;
        int num = 0;
        for (int i = 0; i < h; i++)
        {
            if (arr[i] < result)
            {
                result = arr[i];
                num = 1;
            }
            else if (arr[i] == result)
            {
                num++;
            }
        }
        sw.Write($"{result} {num}");
    }
}