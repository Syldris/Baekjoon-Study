#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        string[] split = text.Split('-');

        int result = 0;
        string[] plus = split[0].Split('+');

        foreach (var item in plus)
        {
            result += int.Parse(item);    
        }

        for (int i = 1; i < split.Length; i++)
        {
            string[] num = split[i].Split('+');
            foreach (var item in num)
            {
                result -= int.Parse(item);
            }
        }

        sw.Write(result);
    }
}