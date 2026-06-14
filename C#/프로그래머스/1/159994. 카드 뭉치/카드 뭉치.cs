using System;

public class Solution
{
    public string solution(string[] cards1, string[] cards2, string[] goal)
    {
        int index1 = 0, index2 = 0;

        for (int i = 0; i < goal.Length; i++)
        {
            if (index1 < cards1.Length && cards1[index1] == goal[i]) // 1번 카드 뭉치 읽기
                index1++;
            else if (index2 < cards2.Length && cards2[index2] == goal[i]) // 2번 카드 뭉치 읽기
                index2++;
            else
                return "No";
        }

        return "Yes";
    }
}