#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 1 << 18));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 1 << 18));

        int n = int.Parse(sr.ReadLine());
        List<int> odd = new List<int>();
        List<int> even = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            if ((a + b) % 2 == 1)
                odd.Add(i);
            else
                even.Add(i);
        }

        if (odd.Count > 0 && even.Count > 0)
        {
            sw.WriteLine("YES");
            sw.Write(String.Join(' ', odd));
            sw.Write(' ');
            sw.Write(String.Join(' ', even));
        }
        else
        {
            sw.WriteLine("NO");
        }
    }
}