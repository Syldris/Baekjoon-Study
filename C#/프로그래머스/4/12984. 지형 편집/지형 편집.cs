using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

public class Solution
{
    public long solution(int[,] land, int p, int q)
    {
        long answer = long.MaxValue;

        // 관찰1. 여러개 나뉜 지형높이에서 높이를 고르게 맞출때,
        // 서로 다른 층 n개.. => 2개=> 1개 이런식으로 병합되는데 층2개 시점에서 올라가는 비용 a, 내려가는 비용b
        // 비교해서 최적으로 이동하는데. 최적위치는 원래 처음의 n개층중 하나이다. (계속 병합해서 층을 줄이기 떄문)

        // 예) 1 2  4 5 있으면 1<->2 4<->5 병합. (1,2) <-> (4,5) 병합 이런식이므로
        // 항상 처음 n개층중 하나가 최적.

        int n = land.GetLength(0);

        // 필요한것 Count, 높이마다 설치값 제거값

        // [높이] = 갯수 
        Dictionary<int, int> dict = new();

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (dict.TryGetValue(land[r, c], out int x))
                    dict[land[r, c]] = x + 1;
                else
                    dict.Add(land[r, c], 1);
            }
        }

        // (높이, 갯수)
        List<(int height, int number)> list = new();
        foreach ((int height, int number) in dict)
        {
            list.Add((height, number));
        }

        list.Sort(); // 높이 오름차순 정렬

        // 값만 저장함. 시작층들 hegiht 높이로 모든칸의 높이를 같게 만들었을때,
        // 설치 | 제거 해야하는 블럭의 양.
        long[] addList = new long[list.Count];
        long[] removeList = new long[list.Count];

        long value = 0;
        int prevHeight = 0;
        long ground = 0; // 계산 과정중 오버플로 방지.

        for (int i = 0; i < list.Count; i++)
        {
            (int height, int number) = list[i];

            value += (height - prevHeight) * ground; // 높이차 * 땅갯수 만큼 블록 증가

            addList[i] = value; // 설치해야하는 블록갯수 등록.

            prevHeight = height;
            ground += number; // 땅 갯수 추가
        }

        value = 0;
        ground = 0;

        for (int i = list.Count - 1; i >= 0; i--)
        {
            (int height, int number) = list[i];

            value += (prevHeight - height) * ground; // 높이차 * 땅갯수 만큼 블록 증가

            removeList[i] = value; // 설치해야하는 블록갯수 등록.

            prevHeight = height;
            ground += number; // 땅 갯수 추가
        }

        for (int i = 0; i < list.Count; i++)
        {
            answer = Math.Min(answer, addList[i] * p + removeList[i] * q);
        }

        return answer;
    }
}