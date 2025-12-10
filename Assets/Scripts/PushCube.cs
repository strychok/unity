using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushableBox : MonoBehaviour, IInteractable
{
    Rigidbody rb;

    public float pushForce = 300f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public void Interact()
    {
        
        //Vector3 pushDir = transform.forward;
        //rb.AddForce(pushDir * pushForce);

        Debug.Log("Cube interacted!");
    }
}
