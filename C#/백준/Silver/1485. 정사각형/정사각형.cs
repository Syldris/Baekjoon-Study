#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        for (int t = 0; t < n; t++)
        {
            int[] input1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] input3 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] input4 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            (int x, int y)[] point = new (int, int)[4];
            point[0] = (input1[0], input1[1]);
            point[1] = (input2[0], input2[1]);
            point[2] = (input3[0], input3[1]);
            point[3] = (input4[0], input4[1]);


            List<long> dist = new List<long>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    long dx = point[i].x - point[j].x;
                    long dy = point[i].y - point[j].y;
                    dist.Add(dx * dx + dy * dy);
                }
            }
            bool square = true;

            dist.Sort();

            if (dist[4] != dist[5]) // 대각
            {
                square = false;
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    if (dist[i] != dist[0]) // 변
                    {
                        square = false;
                    }
                }
            }

            sw.WriteLine(square ? 1 : 0);
        }
    }
}