#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int testcase = int.Parse(sr.ReadLine());
        int setNumber = 0;

        while (testcase-- > 0)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int m = input[0];
            int n = input[1];
            int p = input[2];

            (bool right, int penalty)[,] answer = new (bool, int)[p, m]; // [사람, 문제] = 정답 여부, 틀린 횟수
            (int id, int problem, int score)[] info = new (int, int, int)[p];
            for (int i = 0; i < p; i++)
            {
                info[i].id = i + 1;
            }

            for (int i = 0; i < n; i++)
            {
                string[] line = sr.ReadLine().Split();

                int num = int.Parse(line[0]) - 1;
                int problem = line[1][0] - 'A';
                int time = int.Parse(line[2]);
                bool right = line[3] == "1";

                if (right)
                {
                    if (!answer[num, problem].right) // 아직 안맞은 문제만.
                    {
                        answer[num, problem].right = true;

                        info[num].problem += 1;
                        info[num].score += time + answer[num, problem].penalty * 20; // 시간 + 틀린횟수 *20
                    }
                }
                else
                {
                    answer[num, problem].penalty += 1;
                }
            }

            Array.Sort(info, (a, b) =>
            {
                if (a.problem != b.problem)
                    return b.problem.CompareTo(a.problem); // 문제수가 많은순서부터 내림차순.
                else
                    return a.score.CompareTo(b.score); // 문제수가 같다면 총점수가 낮은 사람부터 오름차순.
            });

            sw.WriteLine($"Data Set {++setNumber}:");
            for (int i = 0; i < info.Length; i++)
            {
                sw.WriteLine($"{info[i].id} {info[i].problem} {info[i].score}");
            }

            if (testcase != 0)
                sw.WriteLine();
        }
    }
}