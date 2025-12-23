using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Interact() {
        
    }
    public void Activate() {
        rb.isKinematic = false;
        this.tag = "CanHandle";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
