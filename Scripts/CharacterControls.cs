using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;

    private PlayerInput input;
    private Vector2 movementInput;
    private Vector2 lookInput;

    private Animator animator;

    private void Awake()
    {
        input = new PlayerInput();

        input.CharacterControls.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        input.CharacterControls.Movement.canceled += ctx => movementInput = Vector2.zero;

        input.CharacterControls.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        input.CharacterControls.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        Vector3 movementDirection = transform.TransformDirection(movement);

        if (movementInput.y < 0f)
        {
            // Move backward
            movementDirection *= -1f;
        }

        transform.position += movementDirection * movementSpeed * Time.deltaTime;

        bool isMoving = movement.magnitude > 0f;
        animator.SetBool("isRunning", isMoving);
    }

    private void RotatePlayer()
    {
        float mouseX = lookInput.x;

        // Rotate left or right when moving with "A" or "D" keys
        if (movementInput.x < 0f)
        {
            transform.Rotate(Vector3.up, -rotationSpeed);
        }
        else if (movementInput.x > 0f)
        {
            transform.Rotate(Vector3.up, rotationSpeed);
        }
        else
        {
            transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        }
    }
}