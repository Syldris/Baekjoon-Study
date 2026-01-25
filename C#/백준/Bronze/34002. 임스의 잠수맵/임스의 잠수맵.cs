#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int a = input[0];
        int b = input[1];
        int c = input[2];

        int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int s = input2[0] * 30;
        int v = input2[1] * 30;

        int level = int.Parse(sr.ReadLine());
        int exp = 25000 - level * 100;


        int result = 0;
        while (exp > 0)
        {
            if (v > 0)
            {
                exp -= c;
                v--;
            }
            else if (s > 0)
            {
                exp -= b;
                s--;
            }

            else exp -= a;
            result++;
        }

        sw.Write(result);
    }
}