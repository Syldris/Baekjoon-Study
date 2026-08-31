using System;
using System.Collections.Generic;
public class Solution
{
    string[] answer;

    Dictionary<string, int> dict = new Dictionary<string, int>();
    List<(int nextArea, string name, bool use)>[] graph;
    bool[] visited;

    int areaSize = 0;
    int ticket = 0;
    public string[] solution(string[,] tickets)
    {
        ticket = tickets.GetLength(0);
        for (int i = 0; i < ticket; i++)
        {
            string from = tickets[i, 0];
            string to = tickets[i, 1];

            if (!dict.ContainsKey(from)) // 지역이름 => 번호 로 매핑.
                dict.Add(from, areaSize++);

            if (!dict.ContainsKey(to))
                dict.Add(to, areaSize++);
        }

        answer = new string[ticket + 1];
        visited = new bool[areaSize];

        // 다음지역번호,지역 이름, 티켓 사용여부
        graph = new List<(int nextArea, string name, bool use)>[areaSize];
        for (int i = 0; i < graph.Length; i++)
            graph[i] = new List<(int nextArea, string name, bool use)>();

        for (int i = 0; i < tickets.GetLength(0); i++)
        {
            int from = dict[tickets[i, 0]];
            int to = dict[tickets[i, 1]];

            graph[from].Add((to, tickets[i, 1], false)); // 단방향 길.
        }

        for (int i = 0; i < graph.Length; i++) // 이름순으로 정렬해서 사전순이 앞에 오게끔.
            graph[i].Sort((a, b) => a.name.CompareTo(b.name));

        visited[dict["ICN"]] = true; // ICN 공항에서 항상 출발
        answer[0] = "ICN";

        DFS(1, dict["ICN"], 1);

        return answer;
    }

    bool DFS(int depth, int curArea, int visitedArea)
    {
        if (depth == ticket + 1 && visitedArea == areaSize) // 항공권을 모두 사용하고, 모든 지역을 방문했다면 성공 판정.
        {
            return true;
        }

        for (int i = 0; i < graph[curArea].Count; i++)
        {
            (int nextArea, string name, bool use) = graph[curArea][i];

            if (use) continue; // 사용한 티켓은 재사용 금지.

            int addArea = visited[nextArea] ? 0 : 1; // 미방문한 지역이였다면 방문지역갯수 +1

            visited[nextArea] = true;
            graph[curArea][i] = (nextArea, name, true); // 티켓 사용 체크.

            answer[depth] = name; //방문 순서에 이름 기록.

            if (DFS(depth + 1, nextArea, visitedArea + addArea)) // 성공여부 전달
                return true;

            // 모두 방문하지 못했다면 되돌아가기.

            if (addArea == 1) // 이번에 첫방문이엿다면
                visited[nextArea] = false; // 미방문처리.

            graph[curArea][i] = (nextArea, name, false); // 티켓은 다시 안쓴거로.
        }
        return false;
    }
}