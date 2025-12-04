#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        string[] input = sr.ReadLine().Split();
        (int x, int y) pos = (int.Parse(input[0]), int.Parse(input[1]));

        (int x, int y)[] arr = new (int x, int y)[n];
        arr[0] = (pos.x, pos.y);

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            arr[i] = (int.Parse(line[0]), int.Parse(line[1]));
        }

        int value = 0;
        int max = 0;

        for (int i = 1; i < n - 1; i++)
        {
            int point = Math.Abs(arr[i].x - arr[i - 1].x) + Math.Abs(arr[i].y - arr[i - 1].y);

            int check = point + Math.Abs(arr[i + 1].x - arr[i].x) + Math.Abs(arr[i + 1].y - arr[i].y);

            int skip = Math.Abs(arr[i + 1].x - arr[i - 1].x) + Math.Abs(arr[i + 1].y - arr[i - 1].y);

            max = Math.Max(max, check - skip);

            value += point;
        }

        value += Math.Abs(arr[^2].x - arr[^1].x) + Math.Abs(arr[^2].y - arr[^1].y);

        sw.Write(value - max);
    }
}