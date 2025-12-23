using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawnState : PlayerBaseState
{
    public PlayerRespawnState(PLayerStateMAchine currentContext, PlayerStateFact playerStateFact) : base (currentContext, playerStateFact) { }
    public IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(5.1f);
        _ctx.animator.SetBool("isRespawn", false);
        _ctx.canMove = true;
    }
    public override void EnterState() {
        _ctx.transform.position = new Vector3(-2, .17f, 0);
        _ctx.transform.rotation = Quaternion.identity;
        _ctx.Drop();
        _ctx.canMove = false;
        Debug.Log("Resp");
        HandleRespawn();
    }
    public override void UpdateState() { 
        CheckSwitchStates();
    }
    public override void ExitState() { }
    public override void CheckSwitchStates() {
        if (_ctx.canMove) {
            SwitchState(_fact.Idle());
        }
    }
    public override void InititalizeSubState() { }

    void HandleRespawn() {
        _ctx.StartCoroutine(RespawnRoutine());
        _ctx.animator.SetBool("isRespawn", true);
        
    }
}
