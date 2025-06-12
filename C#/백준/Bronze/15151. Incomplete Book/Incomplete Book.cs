#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int k = int.Parse(input[0]);
        int d = int.Parse(input[1]);
        int value = 0;
        int sum = 0;
        while (true)
        {
            sum += k;
            k *= 2;
            if(sum > d)
                break;
            value++;
        }
        sw.Write(value);
    }
}