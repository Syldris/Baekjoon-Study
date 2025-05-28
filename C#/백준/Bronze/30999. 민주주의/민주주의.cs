#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        int value = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            int count = 0;
            foreach (var item in line)
            {
                if(item == 'O')
                    count++;
            }
            if (count > m / 2)
                value++;
        }
        sw.Write(value);
    }
}