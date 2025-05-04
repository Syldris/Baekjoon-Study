## [백준 1854번: K번째 최단경로 찾기 ](https://github.com/Syldris/Baekjoon-Study/tree/main/C%23/%EB%B0%B1%EC%A4%80/Platinum/1854.%E2%80%85K%EB%B2%88%EC%A7%B8%E2%80%85%EC%B5%9C%EB%8B%A8%EA%B2%BD%EB%A1%9C%E2%80%85%EC%B0%BE%EA%B8%B0)

- **N개의 도시**, **M개의 도로**, **출발 도시 1번**
- 각 도시까지의 **최단 경로 중 K번째**로 짧은 경로 길이를 출력
- **K번째 최단 거리**가 없으면 `-1` 출력

---
>📌 **우선순위큐(MaxHeap)로 각 노드의 K개의 최단 경로만 유지하면서 효율적으로 구현한 문제!**
### 💡 핵심 개념

1. **각 노드마다 K개의 최단 거리 후보 저장**  
   → 일반 리스트 말고 **우선순위큐(MaxHeap 방식)** 사용  
   → `Peek()`으로 **가장 큰 값(=가장 느린 경로)** 쉽게 확인 가능  

2. **MaxHeap 구현법**  
   → `PriorityQueue<int, int>` 사용  
   → **우선순위**를 `-cost`로 넣으면 **가장 큰 cost**가 **top**에 옴

---
### ✅ 정리
- MaxHeap 방식의 우선순위 큐 덕분에 리스트 정렬 없이 효율적으로 구현 가능

- 시간복잡도는 약 O(K * (V + E) log K) 정도

- 중요한 건: **MaxHeap 방식으로 k번째까지만 유지하기 때문에 메모리 절약 + 빠름!**

---
### 🧠 배운 점
- 우선순위큐를 **MaxHeap**처럼 사용하려면 우선순위를 **부호 반전**으로 넣으면 된다.
- 각 노드마다 **K개**만 관리하면 되기 때문에 **메모리 효율적**이다.
- 일반 **다익스트라**와는 다르게 “**경로가 여러 개일 수 있음**”에 **주의!**
---
### 💻 사용한 C# 핵심 코드

```csharp
PriorityQueue<int, int>[] dist = new PriorityQueue<int, int>[n + 1];
for (int i = 1; i <= n; i++) dist[i] = new PriorityQueue<int, int>(); // MaxHeap방식 

dist[1].Enqueue(0, 0);  // 시작점

PriorityQueue<(int pos, int cost), int> queue = new();
queue.Enqueue((1, 0), 0);

while (pq.Count > 0)
{
    (int now, int cost) = queue.Dequeue();
    foreach (var (next, nextCost) in graph[now])
    {
        int newCost = cost + nextCost;
        if (dist[next].Count < k) // k개보다 적으면 우선 저장
        {
            dist[next].Enqueue(newCost, -newCost); // MaxHeap을 위해 우선순위를 -로 적용
            queue.Enqueue((next, newCost), newCost);
        }
        else if (dist[next].Peek() > newCost) // k개보다 많으면 가장 큰 값과 비교후 큰 값 제거
        {
            dist[next].Dequeue();
            dist[next].Enqueue(newCost, -newCost);
            queue.Enqueue((next, newCost), newCost);
        }
    }
}
```
---
### 📌 출력 처리
```csharp
for (int i = 1; i <= n; i++)
{
    if (dist[i].Count < k)
        Console.WriteLine(-1); // K번째 최단거리 없을땐 -1 출력
    else
        Console.WriteLine(dist[i].Dequeue());  // 가장 느린 K번째 최단거리
}
```
