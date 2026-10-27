using System;

public class Solution
{
    public int solution(int n, int[] lost, int[] reserve)
    {
        int answer = 0;

        bool[] clothes = new bool[n];
        Array.Fill(clothes, true);

        // 체육복 도난으로 없어짐.
        for (int i = 0; i < lost.Length; i++)
        {
            int index = lost[i] - 1;
            clothes[index] = false;
        }

        // 도난 맞은 학생이 여분 체육복이 있으면 바로 입고 빌려줄순 없음.
        for (int i = 0; i < reserve.Length; i++)
        {
            int index = reserve[i] - 1;
            if (!clothes[index])
            {
                clothes[index] = true;
                reserve[i] = -1; // 여분 입었으니 못빌려주게 처리.
            }
        }

        Array.Sort(reserve); // 왼쪽 여분부터 처리.

        // 여분의 체육복을 나눠줌. 왼쪽 여분부터 여분을 왼쪽먼저, 오른쪽 학생에게 나눠주면 최적.
        // 반대로 오른쪽 여분부터 오른쪽 먼저, 그후 왼쪽 줘도 최적. 안나눠주는 학생복이 없게만 하면 됨.
        for (int i = 0; i < reserve.Length; i++)
        {
            if (reserve[i] == -1) continue; 

            int index = reserve[i] - 1;

            if (index - 1 >= 0 && !clothes[index - 1])
                clothes[index - 1] = true;
            else if (index + 1 < n && !clothes[index + 1])
                clothes[index + 1] = true;
        }


        for (int i = 0; i < n; i++)
            if (clothes[i]) answer++;

        return answer;
    }
}