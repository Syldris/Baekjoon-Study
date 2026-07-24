using System;
using System.Collections.Generic;
using System.Text;
public class Solution
{
    public int solution(string word)
    {
        DFS(0);

        return dict[word];
    }

    StringBuilder sb = new StringBuilder();
    Dictionary<string, int> dict = new Dictionary<string, int>();

    char[] alphaBet = new char[5] { 'A', 'E', 'I', 'O', 'U' };

    char[] text = new char[5];
    int value = 0;

    void DFS(int depth)
    {
        dict.Add(sb.ToString(), value++);

        if(depth >= 5) return;

        for (int i = 0; i < 5; i++)
        {
            sb.Append(alphaBet[i]);
            DFS(depth + 1);
            sb.Length -= 1; // 뒤에서 빠르게 1글자 지우기.
        }
    }
}