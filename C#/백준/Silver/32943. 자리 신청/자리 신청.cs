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
        bool[] notEmpty = new bool[c + 1];

        (int time, int seat, int num)[] info = new (int, int, int)[k];
        for (int i = 0; i < k; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            info[i] = (line[0], line[1], line[2]);
        }

        Array.Sort(info);
        foreach ((int time, int seat, int num) in info)
        {
            if (!notEmpty[seat])
            {
                int curSeat = student[num];
                if (curSeat != 0)
                {
                    notEmpty[curSeat] = false;
                }
                student[num] = seat;
                notEmpty[seat] = true;
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