public abstract class PlayerBaseState
{
    protected PLayerStateMAchine _ctx;
    protected PlayerStateFact _fact;
    public PlayerBaseState(PLayerStateMAchine ctx, PlayerStateFact fact)
    {
        _ctx = ctx;
        _fact = fact;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InititalizeSubState();

    protected void UpdateStates() { }
    
    protected void SwitchState(PlayerBaseState newState) {
        ExitState();
        newState.EnterState();
        _ctx.CurrentState = newState;
    }

    protected void SetSubState() { }
}
