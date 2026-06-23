using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] fees, string[] records)
    {
        int[] parkingTime = new int[10000]; // 0~9999번 까지 [차량번호] = 주차시간.
        int[] prevTime = new int[10000]; // 이전 입차 시간.

        Array.Fill(prevTime, -1);

        for (int i = 0; i < records.Length; i++)
        {
            string[] split = records[i].Split(' ');
            string[] split1 = split[0].Split(':');

            int time = int.Parse(split1[0]) * 60 + int.Parse(split1[1]);
            int carNumber = int.Parse(split[1]);

            if (split[2] == "IN")
            {
                prevTime[carNumber] = time;
            }
            else
            {
                parkingTime[carNumber] += time - prevTime[carNumber];
                prevTime[carNumber] = -1; // 출차.
            }
        }

        List<int> answer = new List<int>();
        for (int i = 0; i < 10000; i++)
        {
            if (prevTime[i] != -1) // 입차되고 출차 안된차 조회
            {
                parkingTime[i] += 1439 - prevTime[i]; // 23시 59분까지.
            }

            if (parkingTime[i] != 0)
            {
                int cost = fees[1]; // 기본 요금.

                if (parkingTime[i] > fees[0]) // 기본 시간을 초과했으면 추가비용
                {
                    int diff = parkingTime[i] - fees[0];

                    int add = diff / fees[2]; // 단위 시간으로 나눔. 
                    if (diff % fees[2] > 0) // 안 나눠 떨어지면 추가로 올림.
                        add++;

                    cost += add * fees[3];
                }
                answer.Add(cost);
            }
        }


        return answer.ToArray();
    }
}