#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int result = 0;

        BackTrack(0);

        void BackTrack(int value)
        {
            if (value > n)
                return;

            result = Math.Max(result, value);

            for (int i = 0; i < k; i++)
            {
                BackTrack(value * 10 + arr[i]);
            }
        }

        sw.Write(result);

    }
}