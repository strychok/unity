public class PlayerStateFact
{
    PLayerStateMAchine context;

    public PlayerStateFact (PLayerStateMAchine currentContext) { 
        context = currentContext;
    }

    public PlayerBaseState Idle() {
        return new PLayerIdleState(context, this);
    }
    public PlayerBaseState Walk() {
        return new PlayerWalkingState(context, this);
    }
    public PlayerBaseState Handle() {
        return new PlayerHandleState(context, this); 
    }
    public PlayerBaseState Interact() {
        return new PlayerInteractState(context, this);
    }
    public PlayerBaseState Respawn() { 
        return new PlayerRespawnState(context, this);
    }
}



