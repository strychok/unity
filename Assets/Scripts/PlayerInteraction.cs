using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    public float sphereRadius = 0.3f;
    public float heightOffset = 0.2f;

    void OnInteract()
    {
        Vector3 origin = transform.position + Vector3.forward * heightOffset;

        Collider[] hits = Physics.OverlapSphere(origin, sphereRadius, interactLayer);
        foreach (var col in hits)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                //Debug.Log("Interacted with " + col.name);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 origin = transform.position + Vector3.forward * heightOffset;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(origin, sphereRadius);
    }
}
