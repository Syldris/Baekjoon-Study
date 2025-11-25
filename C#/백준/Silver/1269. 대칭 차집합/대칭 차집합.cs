#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int alen = int.Parse(input[0]);
        int blen = int.Parse(input[1]);

        int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] b = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        HashSet<int> hashA = new HashSet<int>();
        HashSet<int> hashB = new HashSet<int>();

        for (int i = 0; i < alen; i++)
        {
            hashA.Add(a[i]);
        }
        for (int i = 0; i < blen; i++)
        {
            hashB.Add(b[i]);
        }

        int result = 0;

        for (int i = 0; i < alen; i++)
        {
            if (!hashB.Contains(a[i]))
            {
                result++;
            }
        }
        for (int i = 0; i < blen; i++)
        {
            if (!hashA.Contains(b[i]))
            {
                result++;
            }
        }

        sw.Write(result);
    }
}