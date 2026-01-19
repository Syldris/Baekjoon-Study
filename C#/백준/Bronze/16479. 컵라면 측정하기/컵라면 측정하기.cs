#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int k = int.Parse(sr.ReadLine());
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int d1 = input[0];
        int d2 = input[1];

        float a = (float)(d1 - d2) / 2;

        float result = k * k - a * a;
        sw.Write(result);
    }
}