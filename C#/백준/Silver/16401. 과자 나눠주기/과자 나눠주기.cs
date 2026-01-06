#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int start = 0, end = 1000000000;

        while (start < end)
        {
            int mid = (start + end) / 2;
            int value = 0;

            foreach (var item in arr)
            {
                if (value >= m) break;
                value += item / (mid + 1);
            }

            if (value >= m)
            {
                start = mid + 1;
            }
            else
            {
                end = mid;
            }
        }
        sw.Write(start);
    }
}