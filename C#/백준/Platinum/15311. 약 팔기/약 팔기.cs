#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        sw.WriteLine(1999);
        int[] arr = new int[1999];
        for (int i = 0; i < 999; i++)
        {
            arr[i] = 1;
        }
        for (int i = 999; i < 1999; i++)
        {
            arr[i] = 1000;
        }
        sw.WriteLine(String.Join(' ', arr)); 
    }
}