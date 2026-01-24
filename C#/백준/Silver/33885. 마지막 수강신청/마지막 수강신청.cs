#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        (int score, int day, int time)[][] info = new (int, int, int)[n][]; 

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int score = int.Parse(line[0]);
            int size = int.Parse(line[1]);

            info[i] = new (int, int, int)[size];
            for (int j = 0; j < size; j++)
            {
                int day = line[j * 2 + 2] switch
                {
                    "MON" => 0,
                    "TUE" => 1,
                    "WED" => 2,
                    "THU" => 3,
                    "FRI" => 4
                };

                int time = int.Parse(line[j * 2 + 3]);
                info[i][j] = (score, day, time);
            }
        }

        int result = 0;
        bool[,] timetable = new bool[5, 24];

        BackTrack(0, 0);
        sw.Write(result >= m ? "YES" : "NO");

        void BackTrack(int depth, int value)
        {
            if (depth == n)
            {
                result = Math.Max(value, result);
                return;
            }

            int size = info[depth].Length;
            bool able = true;
            for (int i = 0; i < size; i++)
            {
                (int score, int day, int time) = info[depth][i];

                if (timetable[day, time])
                {
                    able = false;
                    break;
                }
            }

            if (able)
            {
                for (int i = 0; i < size; i++)
                {
                    (int score, int day, int time) = info[depth][i];
                    timetable[day, time] = true;
                }

                BackTrack(depth + 1, value + info[depth][0].score);

                for (int i = 0; i < size; i++)
                {
                    (int score, int day, int time) = info[depth][i];
                    timetable[day, time] = false;
                }
            }

            BackTrack(depth + 1, value);
        }
    }
}