using System;

class Solution
{
    public int solution(int n, int[] stations, int w)
    {
        int answer = 0;

        // n = 2억까지 가니 stations 으로 기지국을 몇개 깔아야하는지 체크하면서 가자.
        // stations이 정렬되어있으니 0부터 전파를 모두 연결하면서 진행하자.

        int pos = 0; // 0부터 전파가 닿고있는 현재거리.

        int div = w * 2 + 1; // 하나의 기지국이 처리가능한 구간길이

        foreach (var item in stations)
        {
            // 전파가 닿지않는 빈공간
            int start = pos + 1; // 전파가 안닿는 구간 시작
            int end = item - w - 1; // 전파가 안닿는 구간 끝

            int area = end - start + 1; // 범위이니 구간갯수는 +1

            pos = item + w; // item 위치에 깔았으니 item+w 까지 퍼짐.

            if (area <= 0) continue; // 전파 빈공간 없으면 넘어감

            int setStations = (area + div - 1) / div; // 깔아야 하는 기지국 갯수
            answer += setStations;

        }

        // 마지막 전파부터 ~ n 까지 전파 연결
        int endArea = n - (pos + 1) + 1; // 마지막 전파 위치 +1 ~ n 범위 공간갯수는 +1 

        if (endArea > 0)
        {
            int setStations = (endArea + div - 1) / div;// 깔아야 하는 기지국 갯수
            answer += setStations;
        }

        return answer;
    }
}