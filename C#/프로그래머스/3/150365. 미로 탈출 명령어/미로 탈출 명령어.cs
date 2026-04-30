using System;
using System.Collections.Generic;
using System.Text;
public class Solution
{
    public string solution(int n, int m, int x, int y, int r, int c, int k)
    {
        // 1index => 0index 변경.
        x--;
        y--;
        r--;
        c--;

        // 도착을 위한 최소 포인트.
        int endPoint = Math.Abs(x - c) + Math.Abs(y - r);

        // 홀짝성. 미리 도착했다 해도 2번씩 움직여서 제자리로 올수 있지만 홀짝이 다르면 불가.
        // 이동불가. 최소 움직임이 이동가능한 K보다 많음.
        if (endPoint % 2 != k % 2 || endPoint > k)
        {
            return "impossible";
        }

        // 사전순서 D L R U
        // 순서대로 아래 왼 오 위
        // 사전순으로 d l r u 아 왼 오 위 순이다
        char[] chars = new char[4] { 'd', 'l', 'r', 'u' };

        int[] dx = new int[4] { 0, -1, 1, 0 };
        int[] dy = new int[4] { 1, 0, 0, -1 };

        StringBuilder sb = new StringBuilder();

        int curX = y;
        int curY = x;

        // 그리디 하게 그냥 도착지에 갈수있다 판단되면 아 왼 오 위 순으로 탐색하면서 가능한대로 가면 된다.
        while (k > 0)
        {
            for (int i = 0; i < 4; i++)
            {
                int px = curX + dx[i];
                int py = curY + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;


                // 도착을 위한 최소 거리.
                int dist = Math.Abs(px - c) + Math.Abs(py - r);
                
                // 미리 한칸을 움직였다고 가정하고 남은 포인트만으로 
                // 도착지까지 갈수있는지 체크해야한다. (x,y) => (px,py) 1소모. 
                // px, py 에서 r, c로 갈수있는지 체크.

                if (k - 1 >= dist)
                {
                    sb.Append(chars[i]);

                    // 이동. x y 변경 및 k포인트 감소
                    curX = px;
                    curY = py;
                    k--;
                    break;
                }
            }
        }

        string answer = sb.ToString();
        return answer;
    }
}