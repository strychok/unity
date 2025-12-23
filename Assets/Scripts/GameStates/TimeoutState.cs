using UnityEngine;
using System.Collections;

public class TimeoutState : BaseGameState
{
    StateManager _state;

    public override void EnterState(StateManager state)
    {
        _state = state;
        _state.StartCoroutine(TimeoutRoutine());
        //_state.playerMovement.canInput = false;
    }

    private IEnumerator TimeoutRoutine()
    {
        yield return _state.StartCoroutine(_state.fadeManager.FadeIn());

        yield return new WaitForSeconds(0.5f);

        _state.cameraController.ResetPriority();
        _state.playerStateMachine.canMove = false;

        yield return new WaitForSeconds(0.5f);

        yield return _state.StartCoroutine(_state.fadeManager.FadeOut());

        //_state.playerMovement.canInput = true;
        _state.SwitchState(_state.RoundState);
    }

    public override void UpdateState(StateManager state)
    {
    }
}
