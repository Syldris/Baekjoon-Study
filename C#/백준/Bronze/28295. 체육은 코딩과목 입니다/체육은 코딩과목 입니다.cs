#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int sum = 0;
        for(int i = 0; i < 10; i++)
        {
            int n = int.Parse(sr.ReadLine());
            sum += n;
        }
        switch(sum%4)
        {
            case 0:
                sw.Write('N');
                break;
            case 1:
                sw.Write('E');
                break;
            case 2:
                sw.Write('S');
                break;
            case 3:
                sw.Write('W');
                break;
        }
    }
}