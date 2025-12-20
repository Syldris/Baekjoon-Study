#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        for (int i = 1000000; i > 0; i--)
        {
            bool find = true;
            int num = arr[0] % i;

            if (num < 0)
                num = i + num;

            for (int j = 1; j < n; j++)
            {
                int value = arr[j] % i;
                if (value < 0)
                    value = i + value;

                if (num != value)
                {
                    find = false;
                    break;
                }
            }

            if (find)
            {
                sw.WriteLine(i);
                return;
            }

        }
    }
}