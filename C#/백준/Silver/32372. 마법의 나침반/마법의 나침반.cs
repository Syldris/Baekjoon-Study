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
        (int x, int y) = (1, 1);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int posX = int.Parse(line[0]);
            int posY = int.Parse(line[1]);
            int dir = int.Parse(line[2]);

            switch (dir)
            {
                case 1:
                    if (x >= posX)
                        x = posX - 1;
                    y = posY;
                    break;
                case 2:
                    if (x >= posX)
                        x = posX - 1;
                    if (y <= posY)
                        y = posY + 1;
                    break;
                case 3:
                    x = posX;
                    if (y <= posY)
                        y = posY + 1;
                    break;
                case 4:
                    if (x <= posX)
                        x = posX + 1;
                    if (y <= posY)
                        y = posY + 1;
                    break;
                case 5:
                    if (x <= posX)
                        x = posX + 1;
                    y = posY;
                    break;
                case 6:
                    if (x <= posX)
                        x = posX + 1;
                    if (y >= posY)
                        y = posY - 1;
                    break;
                case 7:
                    x = posX;
                    if (y >= posY)
                        y = posY - 1;
                    break;
                case 8:
                    if (x >= posX)
                        x = posX - 1;
                    if (y >= posY)
                        y = posY - 1;
                    break;
            }
        }
        sw.Write($"{x} {y}");
    }
}