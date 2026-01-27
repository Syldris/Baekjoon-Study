#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] b = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        HashSet<int> hash = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            if (a[i] != b[i])
            {
                sw.Write("NO");
                return;
            }
            hash.Add(a[i]);
        }

        for (int i = n; i < n * 2; i++)
        {
            if (!hash.Contains(b[i]))
            {
                sw.Write("NO");
                return;
            }
        }


        sw.Write("YES");
    }
}