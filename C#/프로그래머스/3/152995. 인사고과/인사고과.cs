using System;
public class Solution
{
    public int solution(int[,] scores)
    {
        // a와 b가 어떤 원소보다 둘다 낮은 경우가 있으면 안되니까 
        // 점수[a] = b 일때 a점수면 최소 b 이상이여야 인센티브를 받는다. 로 설계 
        // (110 40) (100 50) 일때
        // a = 100~109  b점수 40이상 필요. a = 99 이하일때 b점수 50이상 필요. (110 떈 a 충족했으니 필요X)
        // 본인 초과 a값에 대해선 b라도 더 높아야하니
        // 높은 a에서 낮은 a로 b 최댓값을 아래로 전파하면서 됨.

        int[] score = new int[100001];
        int n = scores.GetLength(0);

        int[] total = new int[n];

        for (int i = 0; i < n; i++)
        {
            int a = scores[i, 0];
            int b = scores[i, 1];

            total[i] = a + b;

            if (a > 0) // a = 0 이라면 본인보다 낮은 a가 없음.
            {
                a--; // 본인 미만의 a에 대해 b값를 요구하는거니 a를 1낮춤.
                score[a] = Math.Max(score[a], b); // 나보다 낮은 a는 b 이상이여야한다. 안그러면 a미만,b 미만 충족.
            }
        }

        for (int i = 99999; i >= 0; i--)
        {
            // 본인보다 높은 a에서 온 b값과 비교하면서 기록. 
            // 반대로 높은 a에선 낮은a의 b값을 필요로 하지않음. 왜냐면 a로 충족하니까.
            score[i] = Math.Max(score[i + 1], score[i]);
        }

        int[] index = new int[n];
        for (int i = 0; i < n; i++)
            index[i] = i;

        // total 기준으로 인덱스만 만들어 정렬 (내림차순) 
        Array.Sort(index, (a,b) => total[b].CompareTo(total[a]));

        int rank = 0;
        int sameRank = 1;

        int prevScore = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            int x = index[i]; // i번째로 종합점수가 높은 직원 인덱스.

            int a = scores[x, 0];
            int b = scores[x, 1];

            if (b < score[a]) // 인센티브 못받는사람.(a와 b가 어떤 임의의 사원보다 둘다 낮음)
            {
                if (x == 0) return -1; // 주인공이 인센 못받으면 -1

                continue;
            }

            int totalScore = total[x];
            
            if (totalScore < prevScore) // 이전 석차보다 낮으면
            {
                rank += sameRank;
                sameRank = 1;
            }
            else // 이전과 같으면
            {
                sameRank++; // 동일 석차.
            }

            prevScore = totalScore;

            if (x == 0) // 0번쨰 인덱스가 주인공.
            {
                return rank;
            }
        }

        return 0;
    }
}