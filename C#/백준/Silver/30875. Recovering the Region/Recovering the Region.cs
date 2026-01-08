#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 1; i <= n; i++)
        {
            arr[i - 1] = i;
        }
        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine(String.Join(' ', arr));
        }
    }
}