using UnityEngine;
using System.Collections.Generic;

public class HexCotroller : MonoBehaviour
{
    public bool canRotate = true;
    [SerializeField] private List<RotateHex> hexes;
    public void WinCheck()
    {
        Debug.Log("CLEAR");
        foreach (var hex in hexes) {
            //Debug.Log(hex.CheckRotation());
            if (hex.CheckRotation() == false)
            {

                return;
            }
            
            
        }
        Debug.Log("ALL");
    }

}
