using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TimeoutState : BaseGameState
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("111");
        state.playerMovement.ResetPos();
    }
    public override void UpdateState(StateManager state)
    {
        Debug.Log("ExitRoundState");
    }
}
