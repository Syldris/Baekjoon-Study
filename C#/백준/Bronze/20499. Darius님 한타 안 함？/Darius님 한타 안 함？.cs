#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split('/'),int.Parse);

        int k = arr[0];
        int d = arr[1];
        int a = arr[2];

        if (d == 0 || k + a < d)
            sw.Write("hasu");
        else
            sw.Write("gosu");
    }
}