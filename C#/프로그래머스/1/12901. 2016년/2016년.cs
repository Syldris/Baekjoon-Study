using System;

public class Solution
{
    public string solution(int a, int b)
    {
        string[] dayOfWeek = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };

        int[] month = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // 윤년은 2월이 29일

        int day = 5; // 금요일 시작

        a--; // 1-index => 0-index
        b--;

        for (int i = 0; i < a; i++) // 월 더함
            day += month[i];

        day += b; // 일자 더함

        return dayOfWeek[day % 7];
    }
}