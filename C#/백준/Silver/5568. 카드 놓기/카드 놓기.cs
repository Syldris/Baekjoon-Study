#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        HashSet<int> hash = new HashSet<int>();
        int n = int.Parse(sr.ReadLine());
        int k = int.Parse(sr.ReadLine());
        string[] arr = new string[n];
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = sr.ReadLine();
        }

        BackTrack("", 0);
        sw.Write(hash.Count);
        void BackTrack(string text, int depth)
        {
            if (depth == k)
            {
                hash.Add((int.Parse(text)));
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    string cur = text + arr[i];
                    visited[i] = true;
                    BackTrack(cur, depth + 1);
                    visited[i] = false;
                }
            }
        }
    }
}