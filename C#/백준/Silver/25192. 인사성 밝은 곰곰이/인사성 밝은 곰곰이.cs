#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        HashSet<string> hash = new HashSet<string>();
        int value = 0;
        for (int i = 0; i < n; i++)
        {
            string text = sr.ReadLine();
            if (text == "ENTER")
            {
                hash.Clear();
            }
            else
            {
                if (!hash.Contains(text))
                {
                    value++;
                    hash.Add(text);
                }
            }
        }
        sw.Write(value);
    }
}