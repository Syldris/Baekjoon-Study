#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        sw.Write(arr.Max() - arr.Min());
    }
}