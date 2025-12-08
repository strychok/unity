using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] Timer timer;

    void Start()
    {

        timer.OnTimerFinished += HandleTimerEnd;

        timer.StartTimer(10f);
    }

    // Update is called once per frame
    void HandleTimerEnd() 
    {
        Debug.Log("end");
    }
}
