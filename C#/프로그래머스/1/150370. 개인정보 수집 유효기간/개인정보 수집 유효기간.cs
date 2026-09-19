using System;
using System.Collections.Generic;
public struct Info
{
    public int year;
    public int month;
    public int day;

    public int value => year * 10000 + month * 100 + day; // 숫자로 20201123 년원일순으로 나열하면 기간이 지났는지 바로체크가능.

    public Info(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public void addMouth(int value)
    {
        month += value;

        int diff = (month - 1) / 12;

        year += diff;
        month -= diff * 12;
    }
}

public class Solution
{
    public int[] solution(string today, string[] terms, string[] privacies)
    {
        List<int> answer = new List<int>();

        string[] split = today.Split('.');

        Info todayInfo = new Info(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));

        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (var item in terms)
        {
            split = item.Split();
            dict.Add(split[0], int.Parse(split[1]));
        }

        for (int i = 0; i < privacies.Length; i++)
        {
            split = privacies[i].Split();

            int[] arr = Array.ConvertAll(split[0].Split('.'), int.Parse);

            string type = split[1];

            Info info = new Info(arr[0], arr[1], arr[2]);

            info.addMouth(dict[type]);

            if (todayInfo.value >= info.value)
            {
                answer.Add(i + 1);
            }
        }

        return answer.ToArray();
    }
}