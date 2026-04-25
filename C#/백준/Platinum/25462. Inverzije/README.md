# [Platinum I] Inverzije - 25462 

[문제 링크](https://www.acmicpc.net/problem/25462) 

### 성능 요약

메모리: 30420 KB, 시간: 1128 ms

### 분류

자료 구조, 세그먼트 트리, 오프라인 쿼리, mo's

### 제출 일자

2026년 4월 26일 05:35:26

### 문제 설명

<p>Neka je zadana permutacija $P$ duljine $N$. Permutacija duljine $N$ je niz čiji su elementi različiti prirodni brojevi od $1$ do $N$. Broj inverzija neke permutacije je broj parova $(i, j)$ takvih da je $1 ≤ i < j ≤ N$ i $P_i > P_j$.</p>

<p>Isto tako, broj inverzija permutacija $P$ na intervalu od a do b je broj parova $(i, j)$ takvih da je $a ≤ i < j ≤ b$ i $P_i > P_j$.</p>

<p>Tvoj zadatak je da za zadanu permutaciju $P$ i $M$ zadanih intervala odrediš broj inverzija na svakom od njih.</p>

### 입력 

 <p>U prvom su retku prirodni brojevi $N$ ($1 ≤ N ≤ 100\,000$) i $M$ ($1 ≤ M ≤ 100\,000$), brojevi iz teksta zadatka.</p>

<p>U drugom retku je $N$ različitih prirodnih brojeva $P_i$ ($1 ≤ P_i ≤ N$).</p>

<p>U sljedećih $M$ redaka su prirodni brojevi $a_i$ i $b_i$ ($1 ≤ a_i ≤ b_i ≤ N$), granice intervala čiji broj inverzija tražimo.</p>

### 출력 

 <p>Za svaki od $M$ intervala ispiši broj inverzija permutacije $P$ unutar njega.</p>

