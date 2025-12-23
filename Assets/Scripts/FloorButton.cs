using System.Collections;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] public ButtonChecker buttonChecker;
    [SerializeField] public bool state = false;
    [SerializeField] public bool needed = false;
    public bool canSwitch = true;

    private void Start()
    {
        //if (canSwitch)
        //{
        //    if (state)
        //    {
        //        state = false;
        //        transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
        //    }
        //    else
        //    {
        //        state = true;
        //        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        //    }
        //}
    }
    private void OnTriggerEnter(Collider other)
    {   
        
        Debug.Log("1");
        if (canSwitch){
            Debug.Log("2");
            if (!state)
        {
                Debug.Log("3");
                state = true;
                transform.localPosition = new Vector3(transform.localPosition.x, 0.056f, transform.localPosition.z);
                StartCoroutine(Cooldown());
        }
        else
        {
            state = false;
            transform.localPosition = new Vector3(transform.localPosition.x, 0.1f, transform.localPosition.z);
            StartCoroutine(Cooldown());
        }
    }


        buttonChecker.WinCheck();
        Debug.Log("Apply");
        
    }
    private IEnumerator Cooldown(){
        canSwitch = false;
        yield return new WaitForSeconds(0.5f);
        canSwitch = true;
    }
}   
