
using System.Diagnostics;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public PlayerWalkingState(PLayerStateMAchine currentContext, PlayerStateFact playerStateFact) : base(currentContext, playerStateFact) { }
    public override void EnterState() {
        _ctx.animator.SetBool("isWalking", true);
    }
    public override void UpdateState() {

        CheckSwitchStates();
        handleRotation();
    }
    public override void ExitState() {
        _ctx.animator.SetBool("isWalking", false);
    }
    public override void CheckSwitchStates() {
        if (!_ctx.IsMovementPressed) {
            SwitchState(_fact.Idle());
        }
    }
    public override void InititalizeSubState() { }
    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _ctx.currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = _ctx.currentMovement.z;

        Quaternion currentRotation = _ctx.transform.rotation;

        if (_ctx.IsMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            _ctx.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _ctx.rotationFactorPerFrame * Time.deltaTime);
        }

    }
}
