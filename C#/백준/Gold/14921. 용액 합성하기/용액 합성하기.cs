#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int start = 0, end = n - 1;
        int value = int.MaxValue;
        while (start < end)
        {
            int sum = arr[start] + arr[end];
            if(Math.Abs(sum) < Math.Abs(value))
                value = sum;
            if (sum == 0)
            {
                sw.Write(0);
                return;
            }
            else if(sum < 0)
            {
                start++;
            }
            else
            {
                end--;
            }
        }
        sw.Write(value);
    }
}