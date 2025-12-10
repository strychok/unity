using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] public float sphereRadius = 1f;
    public float heightOffset = 0.2f;
    private bool canPickUp = true;
    public GameObject currentStuff;

    void OnInteract()
    {
        Vector3 origin = transform.position + transform.forward * heightOffset;

        Collider[] hits = Physics.OverlapSphere(origin, sphereRadius, interactLayer);
        foreach (var col in hits)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (col.tag == "CanHandle" & currentStuff == null) {
                    currentStuff = col.transform.gameObject;
                    currentStuff.GetComponent<Rigidbody>().isKinematic = true;
                    currentStuff.transform.parent = transform;
                    currentStuff.transform.localPosition = new Vector3(0f, 0f, 1f);
                    
                    //Debug.Log(col.name);
                }
                Debug.Log(col.name);
                interactable.Interact();
            }
        }
    }

    void OnDrop() {
        if (currentStuff != null)
        {
            currentStuff.transform.parent = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 origin = transform.position + transform.forward * heightOffset;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(origin, sphereRadius);
    }
}
