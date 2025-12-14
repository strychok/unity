using UnityEngine;
using System.Collections.Generic;

public class HexCotroller : MonoBehaviour
{
    [SerializeField] public BatteryContainer batteryContainer;
    public bool canRotate = true;
    [SerializeField] private List<RotateHex> hexes;
    public void WinCheck()
    {
        foreach (var hex in hexes) {
            //Debug.Log(hex.CheckRotation());
            if (hex.CheckRotation() == false)
            {

                return;
            }
            
            
        }
        batteryContainer.powered = true;
        batteryContainer.Interact();
    }

}
