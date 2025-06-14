#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int a = arr[0], b = arr[1], c = arr[2], d = arr[3];

        long ab = long.Parse(new string(a.ToString() + b.ToString()));
        long cd = long.Parse(new string(c.ToString() + d.ToString()));
        sw.Write(ab + cd);
    }
}