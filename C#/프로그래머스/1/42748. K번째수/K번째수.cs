using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] array, int[,] commands)
    {
        int n = commands.GetLength(0);
        int[] answer = new int[n];

        for (int i = 0; i < n; i++)
        {
            // 1-index => 0-index
            commands[i, 0]--;
            commands[i, 1]--;
            commands[i, 2]--;

            List<int> list = new();
            for (int index = commands[i, 0]; index <= commands[i, 1]; index++)
                list.Add(array[index]);

            list.Sort();

            answer[i] = list[commands[i, 2]];
        }

        return answer;
    }
}