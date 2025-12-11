#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
        }

        int green = 0;
        int red = 0;
        int blue = 0;

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();

            if (line[2] == "R")
            {
                red++;
            }
            else if (line[2] == "B")
            {
                blue++;
            }
            else
            {
                green++;
            }
        }

        if (green % 2 == 1)
            red++;

        sw.Write(red > blue ? "jhnah917" : "jhnan917");
    }
}