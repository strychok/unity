using UnityEngine;

public class PLayerIdleState : PlayerBaseState
{
    public PLayerIdleState(PLayerStateMAchine currentContext, PlayerStateFact playerStateFact) : base(currentContext, playerStateFact) { }
    public override void EnterState() {
    }
    public override void UpdateState() {
        CheckSwitchStates();
            }
    public override void ExitState() { }
    public override void CheckSwitchStates() {
        if (_ctx.IsMovementPressed) {
            SwitchState(_fact.Walk());
        }
        if (!_ctx.canMove) { 
            SwitchState(_fact.Respawn());
        }
    }
    public override void InititalizeSubState() { }
    //void Handle() {
    //    if (_ctx.currentStuff != null)
    //    {
    //        _ctx.animator.SetBool("isGrab", true);
    //    }
    //    else if (_ctx.currentStuff != null) { 
    //        _ctx.animator.SetBool()
    //    }
    //}
}
   