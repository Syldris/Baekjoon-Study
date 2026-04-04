#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string text = sr.ReadLine();
        int count = 0;
        HashSet<string> hash = new();

        ReadOnlySpan<char> span = text.AsSpan();

        for (int len = 1; len <= text.Length; len++)
        {
            for (int start = 0; start + len <= text.Length; start++)
            {
                string subtext = text.Substring(start, len);

                hash.Add(subtext);
            }
            count += hash.Count;
            hash.Clear();
        }

        sw.Write(count);
    }
}