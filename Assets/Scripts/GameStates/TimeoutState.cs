using UnityEngine;

public class TimeoutState : BaseGameState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("timeout");
    }
    public override void UpdateState(StateManager state)
    {
        Debug.Log("ExitRoundState");
    }
}
