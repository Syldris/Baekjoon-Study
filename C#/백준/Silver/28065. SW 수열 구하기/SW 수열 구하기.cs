#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int start = 0, end = n;
        List<int> list = new List<int>();

        bool x = true;
        while (start < end)
        {
            if (x)
            {
                list.Add(++start);
            }
            else
            {
                list.Add(end--);
            }
            x = !x;
        }
        sw.Write(String.Join(' ', list));
    }
}