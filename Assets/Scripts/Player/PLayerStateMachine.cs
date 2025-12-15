using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerStateMAchine : MonoBehaviour
{

    Player playerInput;
    CharacterController characterController;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    [SerializeField] float speed = 50f;

    [SerializeField] float rotationFactorPerFrame = 5f;

    PlayerBaseState currentState;
    PlayerStateFact states;
    public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; }  }
    private void Awake()
    {
        states = new PlayerStateFact(this);
        currentState = states.Respawn();
        currentState.EnterState();

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerInput = new Player();
        playerInput.CharacterControl.Move.started += onMovementInput;
        playerInput.CharacterControl.Move.canceled += onMovementInput;
        playerInput.CharacterControl.Move.performed += onMovementInput;
    }
    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovement.x != 0 || currentMovement.z != 0;
    }
    void OnEnable()
    {
        playerInput.CharacterControl.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterControl.Disable();
    }

}

