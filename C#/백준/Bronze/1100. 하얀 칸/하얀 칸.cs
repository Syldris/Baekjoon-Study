using System.Text;
public class Program
{
    static void Main()
    {
        bool[,] board = new bool[8, 8];

        bool color = false;

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                board[x,y] = color;
                color = !color;
            }
            color = !color;
        }

        int count = 0;

        for (int y = 0; y < 8;y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < 8;x++)
            {
                if (!board[x,y] && line[x] == 'F')
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}
