using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BatteryContainer : MonoBehaviour, IInteractable
{
    [SerializeField] public bool powered = false;
    [SerializeField] bool hasBattery;
    [SerializeField] PLayerStateMAchine playerInfo;
    [SerializeField] GameObject battery;
    [SerializeField] private Door door;
    [SerializeField] Light Lighter;
    Color greenColor = new Color(0f, 1f, 0f);
    Color redColor = new Color(1f, 0f, 0f);

    //IEnumerator LightOff() {
    //    yield return new WaitForSeconds(1f);
    //    if (Lighter.color == greenColor)
    //    {
    //        Lighter.color = redColor;
    //    }
    //    else if (Lighter.color == redColor) {
    //        Lighter.color = greenColor;
    //    }
    //}
    //void Start()
    //{
    //    StartCoroutine(LightOff());
    //}
    public void ChangeColor() {
        Debug.Log(Lighter.color);
        if (Lighter.color == greenColor)
        {
            Lighter.color = redColor;
        }
        else if (Lighter.color == redColor)
        {
            Lighter.color = greenColor;
        }
    }

    public void Interact()
    {
        if (playerInfo.currentStuff == battery)
        {   
            Battery batteryScript = battery.GetComponent<Battery>();
            if (!powered & batteryScript.powered)
            {
                ChangeColor();
                TakeBattery();
                door.Open();
                
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
        battery.transform.localPosition = new Vector3(-0.2f, 0.5f, 0f);
        battery.transform.rotation = Quaternion.identity;
        playerInfo.PickupCooldownStart();
        playerInfo.animator.SetBool("isGrab", false);
        playerInfo.currentStuff = null;
        hasBattery = true;
        Debug.Log(battery.transform.parent);

    }
}
