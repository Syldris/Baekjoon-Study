using System;
using System.Collections.Generic;

public struct Cell
{
    public string value;

    public List<(int row, int col)> list = new List<(int row, int col)>();

    public Cell(string value, List<(int row, int col)> list)
    {
        this.value = value;
        this.list = list;
    }
}

public class Solution
{
    Cell[,] board = new Cell[50, 50];
    int[,] parent = new int[50, 50];

    public string[] solution(string[] commands)
    {
        List<string> result = new List<string>();

        for (int r = 0; r < 50; r++)
        {
            for (int c = 0; c < 50; c++)
            {
                board[r, c].list = new List<(int row, int col)>();
                board[r, c].list.Add((r, c));
                board[r, c].value = "";
                parent[r, c] = r * 50 + c;
            }
        }

        for (int i = 0; i < commands.Length; i++)
        {
            string[] command = commands[i].Split(' ');

            if (command[0] == "UPDATE" && command.Length == 3)
            {
                for (int r = 0; r < 50; r++)
                {
                    for (int c = 0; c < 50; c++)
                    {
                        if (board[r, c].value == command[1])
                            board[r, c].value = command[2];
                    }
                }
                continue;
            }

            // 1-index => 0-index
            int row = int.Parse(command[1]) - 1;
            int col = int.Parse(command[2]) - 1;

            int x = Find(row * 50 + col); // 원본 root찾기

            int rootRow = x / 50;
            int rootCol = x % 50;

            if (command[0] == "UPDATE" && command.Length == 4)
            {
                string value = command[3];

                board[rootRow, rootCol].value = value;
            }
            else if (command[0] == "MERGE")
            {
                int row2 = int.Parse(command[3]) - 1;
                int col2 = int.Parse(command[4]) - 1;

                Union(row, col, row2, col2);
            }
            else if (command[0] == "UNMERGE")
            {
                string rootValue = board[rootRow, rootCol].value;

                List<(int row, int col)> rootList = new List<(int row, int col)>(board[rootRow, rootCol].list);

                // 해당 셀 병합 모두 해제
                for (int k = 0; k < rootList.Count; k++)
                {
                    int listRow = rootList[k].row;
                    int listCol = rootList[k].col;

                    // 병합 초기화하고 초기상태로 전환.
                    board[listRow, listCol].list.Clear();
                    board[listRow, listCol].list.Add((listRow, listCol));
                    board[listRow, listCol].value = "";

                    parent[listRow, listCol] = listRow * 50 + listCol;
                }

                board[row, col].value = rootValue; // 값을 가지고있는 경우 r,c가 그 값을 가진다.

            }
            else if (command[0] == "PRINT")
            {
                result.Add(board[rootRow, rootCol].value == "" ? "EMPTY" : board[rootRow, rootCol].value);
            }
        }

        return result.ToArray();
    }

    int Find(int x)
    {
        int r = x / 50;
        int c = x % 50;

        if (parent[r, c] != x)
        {
            parent[r, c] = Find(parent[r, c]);
        }

        return parent[r, c];
    }

    void Union(int r1, int c1, int r2, int c2)
    {
        int rootA = Find(r1 * 50 + c1);
        int rootB = Find(r2 * 50 + c2);

        if (rootA == rootB) // 같은 집합이면 스킵
            return;

        // B => A 로 병합
        parent[rootB / 50, rootB % 50] = rootA;

        // B요소 A로 포함
        foreach ((int row, int col) in board[rootB / 50, rootB % 50].list)
        {
            board[rootA / 50, rootA % 50].list.Add((row, col));
        }

        // a가 비어있으면 b의 값을 채움
        if (board[rootA / 50, rootA % 50].value == "")
            board[rootA / 50, rootA % 50].value = board[rootB / 50, rootB % 50].value;
    }
}