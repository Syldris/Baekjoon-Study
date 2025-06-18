#nullable disable
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        (char left, char right)[] tree = new (char, char)[n];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();

            tree[line[0][0] - 'A'] = (line[1][0], line[2][0]);
        }

        FirstDFS('A');
        sw.WriteLine();
        MiddleDFS('A');
        sw.WriteLine();
        EndDFS('A');

        void FirstDFS(char index)
        {
            if(index == '.') 
                return;
            sw.Write(index);
            FirstDFS(tree[index - 'A'].left);
            FirstDFS(tree[index - 'A'].right);
        }

        void MiddleDFS(char index)
        {
            if (index == '.')
                return;
            MiddleDFS(tree[index - 'A'].left);
            sw.Write(index);
            MiddleDFS(tree[index - 'A'].right);
        }

        void EndDFS(char index)
        {
            if (index == '.')
                return;
            EndDFS(tree[index - 'A'].left);
            EndDFS(tree[index - 'A'].right);
            sw.Write(index);
        }
    }
}