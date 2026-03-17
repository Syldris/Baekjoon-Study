#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        Dictionary<long, int> dict = new(100000);
        for (int i = 0; i < n; i++)
        {
            int size = (int)Read();
            for (int j = 1; j <= size; j++)
            {
                long value = Read();

                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict.Add(value, 1);
            }


            bool find = false;
            foreach (var node in dict)
            {
                if (node.Value > size / 2)
                {
                    sw.WriteLine(node.Key);
                    find = true;
                    break;
                }
            }

            if (!find)
                sw.WriteLine("SYJKGW");

            dict.Clear();
        }

        long Read()
        {
            long value = 0;
            int c = sr.Read();
            while ((c < '0' || c > '9') && c != '-')
            {
                c = sr.Read();
            }

            bool minus = false;
            if (c == '-')
            {
                minus = true;
                c = sr.Read();
            }

            while (c >= '0' && c <= '9')
            {
                value = (value * 10) + c - '0';
                c = sr.Read();
            }

            return minus ? -value : value;
        }
    }
}