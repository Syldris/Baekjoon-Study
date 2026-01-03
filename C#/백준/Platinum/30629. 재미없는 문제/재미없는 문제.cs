#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int size = (int)Math.Ceiling(Math.Sqrt(m));
        if (size == 0)
        {
            size = 1;
        }

        List<int> list = new List<int>();

        list.Add(0);
        for (int i = 1; i < size; i++)
        {
            list.Add(1);
        }

        m -= size - 1;

        for (int i = size; i < n; i++)
        {
            if (m >= size)
            {
                list.Add(size);
                m -= size;
            }
            else
            {
                list.Add(m);
                m = 0;
            }
        }

        sw.Write(String.Join(' ', list));
    }
}