using System;
using System.Collections.Generic;
using System.Linq;
public class Solution
{
    public int[] solution(string[] id_list, string[] report, int k)
    {
        int n = id_list.Length;

        // name => index 변환
        Dictionary<string, int> dict = new();

        for (int i = 0; i < n; i++)
            dict.Add(id_list[i], i);

        bool[,] reportedBy = new bool[n, n]; // a => b 가 신고를 했는지 여부. (각 유저는 한유저에 대해 1번만 신고 가능)
        int[] reportCount = new int[n]; // 신고받은 횟수

        for (int i = 0; i < report.Length; i++)
        {
            // 이름들 index로 변환
            int[] indexs = report[i].Split().Select(x => dict[x]).ToArray();

            if (!reportedBy[indexs[0], indexs[1]]) // 첫 신고시 기록
            {
                reportedBy[indexs[0], indexs[1]] = true;
                reportCount[indexs[1]]++;
            }
        }

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                reportedBy[i, j] = false;


        int[] answer = new int[n]; // 자신이 신고한 사람이 밴당했을때 문의메일을 받는다. 이때 받은 문의메일의 갯수.

        for (int i = 0; i < report.Length; i++)
        {
            int[] indexs = report[i].Split().Select(x => dict[x]).ToArray();

            if (reportedBy[indexs[0], indexs[1]]) continue; // 이미 신고해서 메일 받았으면 스킵.

            if (reportCount[indexs[1]] >= k) // 신고했던 사람이 밴당함
            {
                answer[indexs[0]]++; // 신고자는 메일을 받음.
                reportedBy[indexs[0], indexs[1]] = true;
            }
        }

        return answer;
    }
}