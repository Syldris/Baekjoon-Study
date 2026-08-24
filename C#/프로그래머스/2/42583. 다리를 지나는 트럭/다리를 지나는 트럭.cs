using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int bridge_length, int weight, int[] truck_weights)
    {
        int n = truck_weights.Length;

        int curWeight = 0;
        int curTime = 1;

        Queue<(int time, int weight)> queue = new Queue<(int time, int weight)>();

        for (int i = 0; i < n; i++)
        {
            while (weight < curWeight + truck_weights[i])
            {
                int diff = bridge_length - (curTime - queue.Peek().time); // 길이 - 진행도

                if (diff > 0)
                    curTime += diff;

                curWeight -= queue.Dequeue().weight;
            }

            curWeight += truck_weights[i];
            queue.Enqueue((curTime, truck_weights[i])); // (진입 시점,무게) 기록.

            curTime++; // 각 트럭 진입시간엔 1초차이가 필요
        }

        while (queue.Count > 0)
        {
            int diff = bridge_length - (curTime - queue.Peek().time); // 길이 - 진행도

            if (diff > 0)
                curTime += diff;

            queue.Dequeue();
        }

        return curTime;
    }
}