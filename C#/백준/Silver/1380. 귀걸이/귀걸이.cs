#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = 1;
        while (true)
        {
            int n = int.Parse(sr.ReadLine());
            if(n == 0)
                break;

            string[] name = new string[n];
            bool[] notFind = new bool[n];
            for (int i = 0; i < n; i++)
            {
                name[i] = sr.ReadLine();
            }

            for (int i = 0; i < n * 2 - 1; i++)
            {
                string[] line = sr.ReadLine().Split();
                int num = int.Parse(line[0]) - 1;
                notFind[num] = !notFind[num];
            }

            for (int i = 0; i < n; i++)
            {
                if (notFind[i])
                {
                    sw.WriteLine($"{testcase++} {name[i]}");
                    break;
                }
            }
        }
    }
}