#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string line = sr.ReadLine();
        switch (line)
        {
            case "SONGDO":
                sw.WriteLine("HIGHSCHOOL");
                break;
            case "CODE":
                sw.WriteLine("MASTER");
                break;
            case "2023":
                sw.WriteLine("0611");
                break;
            case "ALGORITHM":
                sw.WriteLine("CONTEST");
                break;
        }
    }
}
