using System.Collections;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    [SerializeField] private StateManager _state;
    [SerializeField] private Door door;
    [SerializeField] private BatteryContainer batteryContainer;
    [SerializeField] private Battery battery;
    [SerializeField] private ParticleSystem gas;

    private bool trigger = false;
    IEnumerator FogDelay() {
        yield return new WaitForSeconds(1f);
        RenderSettings.fog = true;
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !trigger) {
            door.Close();
            batteryContainer.ChangeColor();
            battery.tag = "CanHandle";
            battery.GetComponent<Rigidbody>().isKinematic = false;
            _state.SwitchState(_state.RoundState);
            trigger = true;
            gas.Play();
            StartCoroutine(FogDelay());

        }
    }
    void Update()
    {
        
    }
}
