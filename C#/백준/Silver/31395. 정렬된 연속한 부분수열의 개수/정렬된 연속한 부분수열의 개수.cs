#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int value = 1;
        long result = 1;
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > arr[i-1])
            {
                value++;
            }
            else
            {
                value = 1;
            }
            result += value;
        }
        sw.Write(result);
    }
}