#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int value = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                value += arr[j];
            }
            sw.WriteLine(value);
        }
    }
}