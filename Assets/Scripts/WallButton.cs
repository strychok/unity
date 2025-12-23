using System.Collections;
using UnityEngine;

public class WallButton : MonoBehaviour, IInteractable
{
    [SerializeField] public WallButtonChecker buttonChecker;
    [SerializeField] public bool state = false;
    [SerializeField] public bool needed = false;
    public bool canSwitch = true;
    void Start()
    {
        
    }
    public void Interact()
    {
        if (canSwitch)
        {
            Debug.Log("2");
            if (!state)
            {
                Debug.Log("3");
                state = true;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.15f);
                StartCoroutine(Cooldown());
            }
            else
            {
                state = false;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
                StartCoroutine(Cooldown());
            }
        }
        buttonChecker.WinCheck();
    }

    private IEnumerator Cooldown()
    {
        canSwitch = false;
        yield return new WaitForSeconds(0.5f);
        canSwitch = true;
    }
}
