#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string read = sr.ReadLine();
        switch(read)
        {
            case "M": sw.Write("MatKor"); break;
            case "W": sw.Write("WiCys"); break;
            case "C": sw.Write("CyKor"); break;
            case "A": sw.Write("AlKor"); break;
            case "$": sw.Write("$clear"); break;
        }
    }
}