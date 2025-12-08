using UnityEngine;

public abstract class BaseGameState
{
    public abstract void EnterState(StateManager state);

    public abstract void UpdateState(StateManager state);
}
