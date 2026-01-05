#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        string[] text = new string[n];
        for (int i = 0; i < n; i++)
        {
            string s = sr.ReadLine();
            char[] chars = s.ToCharArray();
            Array.Sort(chars);

            text[i] = new string(chars);
        }

        Array.Sort(text);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < k; i++)
        {
            sb.Append(text[i]);
        }

        char[] arr = sb.ToString().ToCharArray();
        Array.Sort(arr);
        string result = new string(arr);

        sw.Write(result);
    }
}