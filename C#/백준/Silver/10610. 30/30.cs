#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();

        int value = 0;
        bool zero = false;
        foreach (var item in text)
        {
            int cur = item - '0';
            if (cur == 0)
            {
                zero = true;
            }
            value += cur;
        }

        if (value % 3 == 0 && zero)
        {
            char[] arr = text.ToCharArray();
            Array.Sort(arr);
            Array.Reverse(arr);

            sw.Write(new string(arr));
        }
        else
        {
            sw.Write(-1);
        }
    }
}