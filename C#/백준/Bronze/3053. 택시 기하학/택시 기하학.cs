#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int r = int.Parse(sr.ReadLine());

        sw.WriteLine(r * r * Math.PI); // 반지름 * 반지름 * 넓이 (원)
        sw.WriteLine((r * 2) * (r * 2) / 2); // 대각선의 가로 * 세로 * 1/2 (마름모)
    }
}