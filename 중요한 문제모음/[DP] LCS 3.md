## [백준 1958번: LCS3](https://github.com/Syldris/Baekjoon-Study/tree/main/C%23/%EB%B0%B1%EC%A4%80/Gold/1958.%E2%80%85LCS%E2%80%853)

### ✅ 문제 요약
- 문자열 A, B, C가 주어졌을 때, **세 문자열에 모두 포함되는 가장 긴 공통 부분 수열**의 길이를 구하는 문제
- 단, 연속일 필요는 없고 **순서만 유지**하면 됨
- **연속된 공통 문자열 길이**를 찾는 문제는 [**공통 부분 문자열**](https://github.com/Syldris/Baekjoon-Study/blob/main/%EC%A4%91%EC%9A%94%ED%95%9C%20%EB%AC%B8%EC%A0%9C%EB%AA%A8%EC%9D%8C/%5BDP%5D%20%EA%B3%B5%ED%86%B5%20%EB%B6%80%EB%B6%84%20%EB%AC%B8%EC%9E%90%EC%97%B4.md)
---

### 💡 핵심 개념

1. **DP (동적 계획법) 3차원 확장**
   - `dp[i][j][k]`: 문자열 A의 i, B의 j, C의 k번째까지 고려했을 때 **공통 부분 수열의 최대 길이**
   - 기존 2차원 LCS 문제에서 3개 문자열을 비교해야 하므로 **3차원 배열**을 사용

2. **점화식**
   - 세 문자가 모두 같을 경우  
     **`dp[i][j][k] = dp[i-1][j-1][k-1] + 1`**
   - 아니라면,  
     **`dp[i][j][k] = max(dp[i-1][j][k], dp[i][j-1][k], dp[i][j][k-1])`**  
   → 셋 중 가장 긴 공통 부분 수열을 가져오는 방식

---

### 💻 C# 코드

```csharp
public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string c = Console.ReadLine();
        int alen = a.Length;
        int blen = b.Length;
        int clen = c.Length;

        // 3차원 DP 배열 선언
        int[,,] dp = new int[alen + 1, blen + 1, clen + 1];

        for (int i = 1; i <= alen; i++)
        {
            char achar = a[i - 1];
            for (int j = 1; j <= blen; j++)
            {
                char bchar = b[j - 1];
                for (int k = 1; k <= clen; k++)
                {
                    char cchar = c[k - 1];
                    // 세 문자가 모두 같으면 이전 dp값 + 1
                    if (achar == bchar && bchar == cchar)
                    {
                        dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                    }
                    else // 셋 중 최댓값 가져오기
                    {
                        dp[i, j, k] = Math.Max(Math.Max(dp[i - 1, j, k], dp[i, j - 1, k]),
                            dp[i, j, k - 1]);
                    }
                }
            }
        }
        Console.WriteLine(dp[alen, blen, clen]);
    }
}
```
