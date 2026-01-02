#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        string[] input2 = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int x = int.Parse(input2[0]);
        int y = int.Parse(input2[1]);
        int diag1 = x + y;
        int diag2 = n - x + y;

        List<(int x, int y, int diag1, int diag2, bool visited)> subArea = new();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                int posX = x + i;
                int posY = y + j;
                if (posX < 1 || posY < 1 || posX > n || posY > n)
                    continue;

                int posdiag1 = posX + posY;
                int posdiag2 = n - posX + posY;
                subArea.Add((posX, posY, posdiag1, posdiag2, false));
            }
        }

        bool check = false;
        for (int i = 0; i < k; i++)
        {
            string[] line = sr.ReadLine().Split();
            int queenX = int.Parse(line[0]);
            int queenY = int.Parse(line[1]);
            int queenDiag1 = queenX + queenY;
            int queenDiag2 = n - queenX + queenY;

            if (x == queenX || y == queenY || diag1 == queenDiag1 || diag2 == queenDiag2)
            {
                check = true;
            }
            for (int v = 0; v < subArea.Count; v++)
            {
                if (subArea[v].visited) continue;

                int curX = subArea[v].x;
                int curY = subArea[v].y;
                int curdiag1 = subArea[v].diag1;
                int curdiag2 = subArea[v].diag2;

                if (curX == queenX || curY == queenY || curdiag1 == queenDiag1 || curdiag2 == queenDiag2)
                {
                    subArea[v] = (curX, curY, curdiag1, curdiag2, true);
                }
            }
        }

        bool mate = true;

        for (int i = 0; i < subArea.Count; i++)
        {
            if (!subArea[i].visited)
            {
                mate = false;
                break;
            }
        }

        if (check && mate)
        {
            sw.Write("CHECKMATE");
        }
        else if (check)
        {
            sw.Write("CHECK");
        }
        else if (mate)
        {
            sw.Write("STALEMATE");
        }
        else
        {
            sw.Write("NONE");
        }
    }
}