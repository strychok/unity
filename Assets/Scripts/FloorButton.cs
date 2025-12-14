using System.Collections;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] public bool state = false;
    [SerializeField] public bool needed = false;
    public bool canSwitch = true;
    private void OnTriggerEnter(Collider other)
    {   
        if (canSwitch)
        {
            if (state)
            {
                state = false;
                transform.position = new Vector3(transform.position.x, 0.54f, transform.position.z);
                StartCoroutine(Cooldown());
            }
            else
            {
                state = true;
                transform.position = new Vector3(transform.position.x, 0.68f, transform.position.z);
                StartCoroutine(Cooldown());
            }
        }
        
    }
    private IEnumerator Cooldown(){
        canSwitch = false;
        yield return new WaitForSeconds(0.5f);
        canSwitch = true;
    }
}   
