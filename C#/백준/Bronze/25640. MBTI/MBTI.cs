#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string name = sr.ReadLine();
        int n = int.Parse(sr.ReadLine());
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            string name2 = sr.ReadLine();
            if(name == name2)
                count++;
        }    
        sw.Write(count);
    }
}