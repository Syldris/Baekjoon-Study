#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        (int count, int value) x1 = (0, 0);
        (int count, int value) x2 = (0, 0);
        (int count, int value) y1 = (0, 0);
        (int count, int value) y2 = (0, 0);

        for (int i = 0; i < 3; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            if (x1.value == 0 || x1.value == a) // 비어있거나 a인경우 count++;
            {
                if (x1.value == 0) x1.value = a;
                x1.count++;
            }
            else
            {
                if (x2.value == 0) x2.value = a;
                x2.count++;
            }

            if (y1.value == 0 || y1.value == b) // 비어있거나 b인경우 count++;
            {
                if (y1.value == 0) y1.value = b;
                y1.count++;
            }
            else
            {
                if (y2.value == 0) y2.value = b;
                y2.count++;
            }
        }

        int x;
        int y;

        if (x1.count == 1) // 직사각형이려면 x,y 에 대해서 같은 좌표 한쌍이 있어야함
            x = x1.value;
        else
            x = x2.value;

        if (y1.count == 1)
            y = y1.value;
        else
            y = y2.value;

        sw.Write($"{x} {y}");
    }
}