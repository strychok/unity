using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ButtonChecker : MonoBehaviour
{
    [SerializeField] private List<FloorButton> buttons;

    public void WinCheck() {
        foreach (var button in buttons)
        {
            if (button.needed & !button.state) {
                return;
            }
        }
        Debug.Log("Completed");
    }
}
