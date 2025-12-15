using UnityEngine;

public class PlayerRespawnState : PlayerBaseState
{
    public PlayerRespawnState(PLayerStateMAchine currentContext, PlayerStateFact playerStateFact) : base (currentContext, playerStateFact) { }
    public override void EnterState() { }
    public override void UpdateState() { }
    public override void ExitState() { }
    public override void CheckSwitchStates() { }
    public override void InititalizeSubState() { }
}
