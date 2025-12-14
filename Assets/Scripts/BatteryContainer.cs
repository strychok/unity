using UnityEngine;

public class BatteryContainer : MonoBehaviour, IInteractable
{
    [SerializeField] public bool powered = false;
    [SerializeField] bool hasBattery;
    [SerializeField] PlayerInteraction playerInfo;
    [SerializeField] GameObject battery;
    [SerializeField] TempDoor door;
    public void Interact()
    {
        if (playerInfo.currentStuff == battery)
        {   
            Battery batteryScript = battery.GetComponent<Battery>();
            if (!powered & batteryScript.powered)
            {
                TakeBattery();
                door.RotateD();
                
                Debug.Log("DoorOpen");
            }
            else if (powered & !batteryScript.powered) 
            {
                TakeBattery();
                Debug.Log("BatteryPowered");
                batteryScript.powered = true;
            }
            else if(!powered & !batteryScript.powered)
            {
                TakeBattery();
                Debug.Log("Nothing");
            }
            else
            {
                TakeBattery();
                Debug.Log("Nothin1g");
            }
        }
    }
    public void TakeBattery()
    {
        //Debug.Log(battery.transform.parent);
        battery.transform.parent = transform;
        battery.transform.localPosition = new Vector3(0f, 0f, -0.5f);
        playerInfo.ResetPickUp();
        playerInfo.currentStuff = null;
        hasBattery = true;
        Debug.Log(battery.transform.parent);

    }
}
