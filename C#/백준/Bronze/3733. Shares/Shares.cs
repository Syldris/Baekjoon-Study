#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while(true)
        {
            string line = sr.ReadLine();
            if(line == null)
                break;
            string[] inputs = line.Split(' ');
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            sw.WriteLine(b / (a + 1));
        }
    }
}