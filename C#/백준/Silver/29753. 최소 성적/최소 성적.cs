#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);

        decimal success = decimal.Parse(input[1]);
        int subjects = 0;
        decimal score = 0m;

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();

            int num = int.Parse(line[0]);
            subjects += num;
            score += GetScore(line[1]) * num;
        }

        int x = int.Parse(sr.ReadLine());
        subjects += x;

        string[] arr = new string[] { "A+", "A0", "B+", "B0", "C+", "C0", "D+", "D0", "F" };

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            decimal value = (score + GetScore(arr[i]) * x) / subjects;
            value = Math.Floor(value * 100) / 100;
            if (value > success)
            {
                sw.Write(arr[i]);
                return;
            }
        }

        sw.Write("impossible");

        decimal GetScore(string text) => text switch
        {
            "A+" => 4.50m,
            "A0" => 4.00m,
            "B+" => 3.50m,
            "B0" => 3.00m,
            "C+" => 2.50m,
            "C0" => 2.00m,
            "D+" => 1.50m,
            "D0" => 1.00m,
            "F" => 0.00m
        };
    }
}