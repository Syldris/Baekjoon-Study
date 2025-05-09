## [백준 5582번: 공통 부분 문자열](https://github.com/Syldris/Baekjoon-Study/tree/main/C%23/%EB%B0%B1%EC%A4%80/Gold/5582.%E2%80%85%EA%B3%B5%ED%86%B5%E2%80%85%EB%B6%80%EB%B6%84%E2%80%85%EB%AC%B8%EC%9E%90%EC%97%B4)

### ✅ 문제 요약
- 두 문자열에서 **연속된 공통 부분 문자열** 중 **가장 긴 길이**를 구하는 문제
- 공통 부분 **수열이 아닌**, **연속된 문자열**만 인정됨

---

### 💡 핵심 개념
1. **DP (동적 계획법)**
   - `dp[i][j]`: 문자열 `a`의 `i-1`번째 문자와 `b`의 `j-1`번째 문자가 같을 때, 그 지점까지의 **연속된** 공통 문자열 길이
   - (**중간부분 생략 가능한** 최장 공통 부분 수열은 [**LCS문제**](https://github.com/Syldris/Baekjoon-Study/blob/main/%EC%A4%91%EC%9A%94%ED%95%9C%20%EB%AC%B8%EC%A0%9C%EB%AA%A8%EC%9D%8C/%5BDP%5D%20LCS%203.md))
> **🔹 만약 `a[i-1] == b[j-1]`이라면 `dp[i][j] = dp[i-1][j-1] + 1` 으로 연속된 문자열 수 저장**
> 
> **🔹 다르면 문자 일치 X → 연속성 끊김 → `dp[i][j] = 0`**

2. **결과 저장**
   - 가장 긴 길이를 따로 `value`에 저장해서 최종 출력

---

### 💻 C# 코드

```csharp
public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        int alen = a.Length;
        int blen = b.Length;

        int value = 0;
        int[,] dp = new int[alen + 1, blen + 1];

        for (int i = 1; i <= alen; i++)
        {
            for (int j = 1; j <= blen; j++)
            {
                if (a[i - 1] == b[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1; //읽으면 둘다 다음 문자열로 넘어가기
                    value = Math.Max(value, dp[i, j]);
                }
            }
        }

        Console.WriteLine(value);
    }
}
```
---
### ✅ 예시
```
입력:
abcdxyz
xyzabcd
```
```출력:4```
- abcd가 두 문자열 모두에 연속으로 존재하는 가장 긴 공통 문자열
