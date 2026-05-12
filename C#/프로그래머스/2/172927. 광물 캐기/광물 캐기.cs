using System;
public struct Mine
{
    public int diamond;
    public int iron;
    public int stone;

    public int value; // 비교기준 값.

    public Mine(int diamond, int iron, int stone, int value)
    {
        this.diamond = diamond;
        this.iron = iron;
        this.stone = stone;
        this.value = value;
    }
}

public class Solution
{
    public int solution(int[] picks, string[] minerals)
    {
        int answer = 0;

        // 광물 5칸씩 묶어서 계산. 20 = 4 21 = 5 등으로
        // 광물은 주어진 순서대로 캘수 있지만 5칸씩 나눠서 곡괭이를 최적화해서 쓰자.

        // 광물은 주어진 순서대로만 캘수있으므로. 곡괭이가 부족하다면 뒤쪽부분은 관계없이 잘라내야만한다.
        // 아예 계산에 들어가면 안된다.
        int len = Math.Min(picks[0] + picks[1] + picks[2], (minerals.Length + 4) / 5);


        // 프로그래머스 버전 이슈로 사용불가. 밸브튜플 에러남.
        //(int ironScore, int stoneScore)[] mine = new (int ironScore, int stoneScore)[len];

        Mine[] mine = new Mine[len];

        for (int i = 0; i < len; i++) // 광물 묶음 계산
        {
            int diamond = 0;
            int iron = 0;
            int stone = 0;

            for (int j = 0; j < 5; j++) // 5개씩 세기.
            {
                int index = i * 5 + j;

                if (index >= minerals.Length) // 5개 미만 남는거 중간에 중단.
                    break;

                if (minerals[index] == "diamond")
                    diamond++;
                else if (minerals[index] == "iron")
                    iron++;
                else
                    stone++;
            }

            // 돌곡괭이로 캘때 기준.
            int value = diamond * 25 + iron * 5 + stone;

            mine[i] = new Mine(diamond, iron, stone, value);
        }

        // 돌곡괭이로 캘때 피로도 기준으로 계산.
        // 다곡 철곡 돌곡 순으로 쓰니. 돌곡을 기준으로 하면.
        // 무거운거부터 다곡. 그이후로 철곡. 돌곡순으로 그리디 가능.

        Array.Sort(mine, (a, b) => b.value.CompareTo(a.value));

        for (int i = 0; i < len; i++)
        {
            if (picks[0] > 0)
            {
                answer += mine[i].diamond + mine[i].iron + mine[i].stone; // 다곡은 1개당 1이다
                picks[0]--;
                continue;
            }
            else if (picks[1] > 0)
            {
                // 다곡 다쓰면 철곡은 1개 소모해서 피로도 증가.
                answer += mine[i].diamond * 5 + mine[i].iron + mine[i].stone;
                picks[1]--;
                continue;
            }
            else if (picks[2] > 0)
            {
                // 돌곡만 남으면 돌곡 사용.
                answer += mine[i].diamond * 25 + mine[i].iron * 5 + mine[i].stone;
                picks[2]--;
                continue;
            }
        }

        return answer;
    }
}