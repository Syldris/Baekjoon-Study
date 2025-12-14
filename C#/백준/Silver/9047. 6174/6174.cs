#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string text = sr.ReadLine();

            int count = 0;
            while (text != "6174")
            {
                char[] arr = text.ToCharArray();
                Array.Sort(arr);
                int min = int.Parse(new string(arr));
                Array.Reverse(arr);
                int max = int.Parse(new string(arr));

                text = (max - min).ToString();
                text = text.PadLeft(4, '0');
                count++;
            }
            sw.WriteLine(count);
        }
    }
}