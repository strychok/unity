using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PLayerStateMAchine : MonoBehaviour
{

    Player playerInput;
    CharacterController characterController;
    public Animator animator;

    Vector2 currentMovementInput;
    public Vector3 currentMovement;
    bool isMovementPressed;
    [SerializeField] float speed = 50f;

    [SerializeField] public float rotationFactorPerFrame = 5f;

    PlayerBaseState currentState;
    PlayerStateFact states;
    public bool IsMovementPressed { get { return isMovementPressed; } }
    public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; }}
    public bool canMove = true;
    public bool die = false;
    public bool interactionPressed = false;
    public bool dropPressed= false;

    public GameObject currentStuff = null;
    public bool canPickup = true;

    public float heightOffset = 1f;
    public float upOffset = 1.29f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] public float sphereRadius = 1f;

    [SerializeField] private float boxWidth = .45f;
    [SerializeField] private float boxHeight = 1.3f;
    [SerializeField] private float boxDepth = .49f;


    private void Awake()
    {
        Debug.Log("aw");
        states = new PlayerStateFact(this);

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerInput = new Player();
        currentState = states.Respawn();
        currentState.EnterState();
        playerInput.CharacterControl.Move.started += onMovementInput;
        playerInput.CharacterControl.Move.canceled += onMovementInput;
        playerInput.CharacterControl.Move.performed += onMovementInput;
        playerInput.CharacterControl.Interact.started += onInteractInput;
        playerInput.CharacterControl.Drop.started += onDropInput;
    }
    void onInteractInput(InputAction.CallbackContext context)
    {
        Debug.Log("input");
        interactionPressed = true;

        Vector3 boxCenter = transform.position + transform.forward * heightOffset + transform.up * upOffset;

        Collider[] hits = Physics.OverlapBox(
            boxCenter,
            new Vector3(boxWidth, boxHeight, boxDepth) * 0.5f,
            transform.rotation,
            interactLayer
        );

        foreach (var col in hits)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (col.tag == "CanHandle" && currentStuff == null && canPickup)
                {
                    currentStuff = col.transform.gameObject;
                    currentStuff.GetComponent<Rigidbody>().isKinematic = true;
                    currentStuff.transform.parent = transform;
                    currentStuff.transform.localPosition = new Vector3(-0.26f, 1.59f, 0.492f);
                    currentStuff.transform.rotation = Quaternion.Euler(-15.2f, 0, 0);
                    StartCoroutine(PickupCooldoown());
                    animator.SetBool("isGrab", true);
                }
                Debug.Log(col.name);
                interactable.Interact();
            }
        }
    }
    void onDropInput(InputAction.CallbackContext context) {
        Drop();
        
    }
    public void Drop() {
        if (currentStuff != null)
        {
            currentStuff.transform.parent = null;
            currentStuff.GetComponent<Rigidbody>().isKinematic = false;
            currentStuff = null;
            animator.SetBool("isGrab", false);
        }
    }
    void onMovementInput(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            isMovementPressed = currentMovement.x != 0 || currentMovement.z != 0;
        }
        
    }
    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y = gravity;
        }
    }
    private void Update()
    {   
        currentState.UpdateState();
        handleGravity();
        if (canMove)
        {
            characterController.Move(currentMovement * Time.deltaTime * speed);
        }
    }

    void OnEnable()
    {
        playerInput.CharacterControl.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterControl.Disable();
    }

    public void PickupCooldownStart() {
        StartCoroutine(PickupCooldoown());
    }
    IEnumerator PickupCooldoown() {
        canPickup = false;
        yield return new WaitForSeconds(1f);
        canPickup = true;
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 boxCenter = transform.position + transform.forward * heightOffset + transform.up* upOffset;

        Gizmos.color = Color.green;

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(boxCenter, transform.rotation, Vector3.one);
        Gizmos.matrix = rotationMatrix;

        Gizmos.DrawWireCube(Vector3.zero, new Vector3(boxWidth * 2, boxHeight * 2, boxDepth * 2));
    }
}

