using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
    [SerializeField] public bool powered = false;
    public void Interact()
    {
        //Debug.Log("battery");
    }
    public void Power() { 
        powered = true;
    }
}
