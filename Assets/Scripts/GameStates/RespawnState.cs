using UnityEngine;

public class RespawnState : BaseGameState
{
    StateManager _state;
    public override void EnterState(StateManager state)
    {
        Debug.Log("RespawnState");
        _state = state;
    }

    // Update is called once per frame
    public override void UpdateState(StateManager state)
    {
        
    }
}
