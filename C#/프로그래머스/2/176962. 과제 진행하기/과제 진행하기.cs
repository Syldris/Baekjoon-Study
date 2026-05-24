using System;
using System.Collections.Generic;
public struct Info
{
    public string name;
    public int startTime;
    public int playTime;

    public Info(string name, int startTime, int playTime)
    {
        this.name = name;
        this.startTime = startTime;
        this.playTime = playTime;
    }
}

public class Solution
{
    public string[] solution(string[,] plans)
    {
        int n = plans.GetLength(0);

        string[] answer = new string[n];
        Info[] info = new Info[n];
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            string name = plans[i, 0];
            string[] startTimeSplit = plans[i, 1].Split(':');

            int startTime = int.Parse(startTimeSplit[0]) * 60 + int.Parse(startTimeSplit[1]);
            int playTime = int.Parse(plans[i, 2]);

            info[i] = new Info(name, startTime, playTime);
        }

        // 시작 시간 기준 정렬
        Array.Sort(info, (a, b) => a.startTime.CompareTo(b.startTime));

        int prevTime = 0;
        Stack<Info> stack = new Stack<Info>();

        for (int i = 0; i < n; i++)
        {
            int startCurTime = info[i].startTime;

            int diffTime = startCurTime - prevTime; // 남은 과제 처리시간 = 시작시간 - 이전시작시간

            while (stack.Count > 0 && diffTime > 0)
            {
                Info pop = stack.Pop();

                if (diffTime >= pop.playTime) // 남은 시간이 같거나 더많으면 해결 가능
                {
                    answer[index++] = pop.name;

                    diffTime -= pop.playTime; // 남은 시간은 과제 시간만큼 감소.
                }
                else
                {
                    pop.playTime -= diffTime; // 남은 시간동안 해결하고
                    stack.Push(pop); // 다시 집어넣음

                    diffTime = 0; // 남은 시간 소진
                }
            }

            stack.Push(info[i]);
            prevTime = startCurTime; // 이전 사적 시간을 미리 저장.
        }

        while (stack.Count > 0)
        {
            Info pop = stack.Pop();
            answer[index++] = pop.name;
        }

        return answer;
    }
}