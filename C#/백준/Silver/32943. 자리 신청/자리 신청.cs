#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int x = int.Parse(input[0]);
        int c = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int[] student = new int[x + 1];
        int[] seat = new int[c + 1];

        (int time, int seat, int num)[] info = new (int, int, int)[k];
        for (int i = 0; i < k; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            info[i] = (line[0], line[1], line[2]);
        }

        info = info.OrderBy(x => x.time).ToArray();
        foreach (var item in info)
        {
            if (seat[item.seat] == 0)
            {
                int curSeat = student[item.num];
                if (curSeat != 0)
                {
                    seat[curSeat] = 0;
                }
                student[item.num] = item.seat;
                seat[item.seat] = item.num;
            }
        }

        for (int i = 1; i <= x; i++)
        {
            if (student[i] != 0)
            {
                sw.WriteLine($"{i} {student[i]}");
            }
        }
    }
}