#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();
        int value = 0;
        for (int i = 0; i < n; i++)
        {
            if (text[i] == 'o')
                value++;
            else
                value = 0;

            if(value == 3)
            {
                sw.Write("Yes");
                return;
            }
        }
        sw.Write("No");
    }
}