using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    public float interactDistance = 2f;

    void OnInteract()
    {
        Debug.Log("Shift");

        RaycastHit hit;
        Vector3 origin = transform.position + Vector3.up * 1f;
        Vector3 direction = transform.forward;
        float radius = 0.5f;
        float maxDistance = 2f;


        if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance, interactLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                print("hit");
            }
        }
    }

    void Update()
    {
    }
}