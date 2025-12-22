#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] passport = new int[k];
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (int i = 0; i < n; i++)
        {
            bool pass = false;
            for (int j = 0; j < k; j++)
            {
                if (arr[i] > passport[j])
                {
                    passport[j] = arr[i];
                    pass = true;
                    break;
                }
            }
            if (!pass)
            {
                sw.Write("NO");
                return;
            }
        }

        sw.Write("YES");
    }
}