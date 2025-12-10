using UnityEngine;

public class RoundState : BaseGameState
{
    StateManager _state;
    public override void EnterState(StateManager state) 
    {   
        _state = state;
        _state.timer.OnTimerFinished += HandleTimer;
        _state.timer.StartTimer(15f);
        Debug.Log("RoundState");
    }
    public override void UpdateState(StateManager state)
    {
    }
    void HandleTimer() {
        _state.SwitchState(_state.TimeoutState);
        Debug.Log("TimerEndInsideRound");
    }
}
  