# ✅ FSM(상태 머신) 패턴 구현

## 💡 핵심 개념
- **인터페이스**: 상태별로 어떤 행동을 해야 하는지 정의하는 양식
- **상태 머신**: 여러 상태 간 전환을 관리하고, 각 상태에서 해야 할 일을 실행하는 시스템
---

### 1. IState 인터페이스 정의
각 상태에서 공통적으로 해야 할 작업들을 메서드로 정의하는 인터페이스를 작성

```csharp
public interface IState
{
    void Enter();   // 상태에 진입할 때 실행할 로직
    void Execute(); // 상태에서 실행할 로직
    void Exit();    // 상태에서 나갈 때 실행할 로직
}
```

### 2. 각 상태 클래스 정의
`IState` 인터페이스를 구현하여, 각 상태별로 진입, 실행, 종료 로직을 정의
```csharp
public class IdleState : IState
{
    public void Enter() => Console.WriteLine("Entering Idle State");
    public void Execute() => Console.WriteLine("Executing Idle State");
    public void Exit() => Console.WriteLine("Exiting Idle State");
}

public class RunState : IState
{
    public void Enter() => Console.WriteLine("Entering Run State");
    public void Execute() => Console.WriteLine("Executing Run State");
    public void Exit() => Console.WriteLine("Exiting Run State");
}

```
### 3. 상태 머신 클래스
상태 머신 클래스는 현재 상태를 관리하고, 상태 전환 및 상태별 로직 실행을 담당
```csharp
public class StateMachine
{
    private IState _currentState;

    public void ChangeState(IState newState)
    {
        _currentState?.Exit();  // 이전 상태 종료
        _currentState = newState;
        _currentState.Enter();   // 새로운 상태 진입
    }

    public void Update()
    {
        _currentState?.Execute(); // 현재 상태에서 실행할 로직
    }
}
```
### 4. 사용 예
상태 머신을 사용해 상태를 전환하고, 각 상태에 맞는 로직을 실행하는 프로그램
```csharp
public class Program
{
    public static void Main()
    {
        StateMachine fsm = new StateMachine();
        
        fsm.ChangeState(new IdleState());  // 처음 Idle 상태로 진입
        fsm.Update();                      // 상태 실행
        
        fsm.ChangeState(new RunState());   // Run 상태로 변경
        fsm.Update();                      // 상태 실행
    }
}

```
# ✅ FSM(상태 머신) 패턴의 장점과 단점

## 💡 장점
- **상태 추가 용이**: 새로운 상태를 추가할 때 기존 코드의 수정 없이 상태 클래스를 추가하는 것으로 충분함.
- **상태 간 전환 관리 용이**: 상태 전환이 명확히 정의되어 있어 관리가 쉽고, 상태 변경 시 다른 상태에 미치는 영향을 최소화할 수 있음.
- **코드의 명확성**: 각 상태별로 해야 할 일이 분리되어 있어 코드가 명확하고 유지보수가 용이함.
- **확장성**: 새로운 상태나 전환을 추가할 때, 기존의 상태 클래스를 수정할 필요 없이 상태 머신 클래스를 통해 확장 가능.

## 💡 단점
- **상태 클래스가 많아질 수 있음**: 상태가 많아지면 그에 따라 상태 클래스도 많아지고 관리해야 할 코드가 늘어날 수 있음!
- **복잡성 증가**: 작은 시스템에서는 오히려 상태 머신 패턴을 사용하는 것보다 단순한 로직을 구현하는 것이 더 효율적일 수 있음!!
- **상태 변경 로직 복잡해짐**: 상태 전환 시 조건이 복잡할 경우, 상태 전환 로직이 비효율적이거나 복잡해질 수 있음!
- **단일 책임 원칙 위반 가능성**: 상태마다 로직을 처리하므로 각 상태 클래스가 너무 많은 책임을 지게 될 수 있어 단일 책임 원칙을 위반할 위험이 있음!
