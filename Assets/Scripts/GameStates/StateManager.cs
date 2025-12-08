using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseGameState currentState;
    [SerializeField] public Timer timer;
    
    public RoundState RoundState = new RoundState();
    public TimeoutState TimeoutState = new TimeoutState();


    void Start()
    {
        currentState = RoundState;
        currentState.EnterState(this);
    }
    public void SwitchState(BaseGameState state) { 
        currentState = state;
        currentState.EnterState(this);
    }
}
