using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool[,] board = new bool[n, n];
        int asnwer = 0;

        void DFS(int row)
        {
            if(row == n)
            {
                asnwer++;
                return;
            }

            for(int col = 0; col < n; col++)
            {
                if(CanPlace(row,col))
                {
                    board[row, col] = true;
                    DFS(row + 1);
                    board[row, col] = false;
                }
            }
        }

        bool CanPlace(int row, int col)
        {
            for(int i = 0; i < row; i++)
            {
                if(board[i, col])
                    return false;
            }

            for (int i = 1; row - i >= 0 && col - i >=0; i++)
            {
                if(board[row-i, col-i])
                    return false;
            }

            for(int i = 1; row - i >= 0 && col + i < n; i++)
            {
                if(board[row-i, col+i])
                    return false;
            }
            return true;
        }

        DFS(0);
        Console.WriteLine(asnwer);
    }
}
