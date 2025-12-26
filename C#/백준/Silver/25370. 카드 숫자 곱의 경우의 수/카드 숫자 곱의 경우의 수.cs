#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        HashSet<int> hash = new HashSet<int>();
        int result = 0;

        BackTrack(0, 1);

        sw.WriteLine(result);

        void BackTrack(int depth, int value)
        {
            if (depth == n)
            {
                if (!hash.Contains(value))
                {
                    hash.Add(value);
                    result++;
                }
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                BackTrack(depth + 1, value * i);
            }
        }
    }
}