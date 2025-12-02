#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());


        for (int t = 0; t < testcase; t++)
        {
            string[] line = sr.ReadLine().Split();

            int m = int.Parse(line[0]);

            if (m == 1)
            {
                int[] arr = line[1].Split('.').Select(int.Parse).Reverse().ToArray();
                ulong result = 0;

                for (int v = 0; v < 8; v++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int bit = (arr[v] >> i & 1);
                        if (bit == 1)
                        {
                            result |= 1ul << (v * 8 + i);
                        }
                    }
                }

                sw.WriteLine(result);
            }
            else
            {
                ulong value = ulong.Parse(line[1]);
                int[] result = new int[8];
                for (int v = 0; v < 8; v++)
                {
                    int cur = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        int bit = (int)(value >> (v * 8 + i) & 1);
                        if (bit == 1)
                        {
                            cur |= 1 << i;
                        }
                    }
                    result[7 - v] = cur;
                }
                sw.WriteLine(String.Join('.', result));
            }
        }
    }
}