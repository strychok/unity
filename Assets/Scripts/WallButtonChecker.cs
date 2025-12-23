using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WallButtonChecker : MonoBehaviour
{
    [SerializeField] private List<WallButton> buttons;
    [SerializeField] private KeyContainer keyContainer;

    public void WinCheck()
    {
        foreach (var button in buttons)
        {
            if (button.needed & !button.state)
            {
                return;
            }
        }
        keyContainer.Open();
    }
}

