using System;
using static System.Math;
public class Solution
{
    int answer = int.MaxValue;
    int n;
    int[] hintCount;

    public int solution(int[,] cost, int[,] hint)
    {
        n = cost.GetLength(0);
        hintCount = new int[n];

        BackTrack(0, 0, cost, hint);

        return answer;
    }

    void BackTrack(int stage, int totalCost, int[,] cost, int[,] hint)
    {
        int stageHint = Math.Min(hintCount[stage], n - 1);

        if (stage == n - 1)
        {
            totalCost += cost[stage, stageHint];
            answer = Math.Min(answer, totalCost);
            return;
        }

        totalCost += cost[stage, stageHint]; // 스테이지 해결 비용 추가

        // 힌트 번들 안사고 가는 경우
        BackTrack(stage + 1, totalCost, cost, hint);

        // 힌트번들 사고 가는 경우
        totalCost += hint[stage, 0];
        for (int i = 1; i < hint.GetLength(1); i++)
        {
            int hintStage = hint[stage, i] - 1; // 1-index => 0-index
            hintCount[hintStage]++;
        }

        BackTrack(stage + 1, totalCost, cost, hint);

        // 힌트 다시 제거
        for (int i = 1; i < hint.GetLength(1); i++)
        {
            int hintStage = hint[stage, i] - 1; // 1-index => 0-index
            hintCount[hintStage]--;
        }
    }
}