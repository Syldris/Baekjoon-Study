#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        for (int t = 0; t < testcase; t++)
        {
            HashSet<int> hash = new HashSet<int>();

            int a = int.Parse(sr.ReadLine());
            int[] arrA = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int b = int.Parse(sr.ReadLine());
            int[] arrB = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int c = int.Parse(sr.ReadLine());
            int[] arrC = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    for (int k = 0; k < c; k++)
                    {
                        bool find = true;
                        int value = arrA[i] + arrB[j] + arrC[k];

                        int number = value;

                        while (value >= 10)
                        {
                            if (!(value % 10 == 5 || value % 10 == 8))
                            {
                                find = false;
                                break;
                            }
                            value /= 10;
                        }

                        if (!(value % 10 == 5 || value % 10 == 8))
                        {
                            find = false;
                        }

                        if(find)
                            hash.Add(number);
                    }
                }
            }

            sw.WriteLine(hash.Count);
        }
    }
}