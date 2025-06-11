#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string input = sr.ReadLine();
        int value = 1;
        for (int i = 0; i < n; i++)
        {
            if (input[i] == 'S')
            {
                value += 1;
            }
            if(input[i] == 'L')
            {
                i++;
                value += 1;
            }
        }
        sw.Write(value > n ? n : value);
    }
}