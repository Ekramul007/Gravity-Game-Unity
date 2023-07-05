using UnityEngine;
using UnityEngine.InputSystem;

public class Hologram_Player : MonoBehaviour
{
    public GameObject upshow;
    public GameObject leftshow;
    public GameObject rightshow;

    private bool isUpArrowPressed;
    private bool isLeftArrowPressed;
    private bool isRightArrowPressed;

    private ConstantForce constantForce;

    public float ForceOnUp = 1000f;
    public float ForceOnLeft = 1000f;
    public float ForceOnRight = 1000f;

    private Vector3 targetPositionUP;
    private Vector3 targetPositionLeft;
    private Vector3 targetPositionRight;

    void Start()
    {
        constantForce = GetComponent<ConstantForce>();
    }

    void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            isUpArrowPressed = true;
            upshow.SetActive(true);
        }

        if (Keyboard.current.upArrowKey.wasReleasedThisFrame)
        {
            isUpArrowPressed = false;
            upshow.SetActive(false);

            // Rotate the player 180 degrees on the Z-axis
            MovePosUP();
            transform.Rotate(0f, 0f, 180f);
            ApplyConstantForceUP();
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            isLeftArrowPressed = true;
            leftshow.SetActive(true);
        }

        if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        {
            isLeftArrowPressed = false;
            leftshow.SetActive(false);

            // Rotate the player 90 degrees on the Z-axis
            MovePosLeft();
            transform.Rotate(0f, 0f, -90f);
            ApplyConstantForceDOWN();
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            isRightArrowPressed = true;
            rightshow.SetActive(true);
        }

        if (Keyboard.current.rightArrowKey.wasReleasedThisFrame)
        {
            isRightArrowPressed = false;
            rightshow.SetActive(false);

            // Rotate the player -90 degrees on the Z-axis
            MovePosRight();
            transform.Rotate(0f, 0f, 90f);
            ApplyConstantForceDOWN();
        }
    }

    void ApplyConstantForceUP()
    {
        constantForce.enabled = true;
        Vector3 upDirection = -transform.up;
        constantForce.force = upDirection * ForceOnUp; // Adjust the magnitude as needed
    }

    void ApplyConstantForceDOWN()
    {
        constantForce.enabled = true;
        Vector3 downDirection = -transform.up;
        constantForce.force = downDirection * ForceOnUp;
    }

    void StopConstantForce()
    {
        constantForce.enabled = false;
        Physics.gravity = -transform.up * ForceOnUp;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            StopConstantForce();
        }
    }

    private void MovePosUP()
    {
        targetPositionUP = upshow.transform.position;

        // Move player to the target position
        transform.position = targetPositionUP;
    }

    private void MovePosLeft()
    {
        targetPositionLeft = leftshow.transform.position;

        // Move player to the target position
        transform.position = targetPositionLeft;
    }

    private void MovePosRight()
    {
        targetPositionRight = rightshow.transform.position;

        // Move player to the target position
        transform.position = targetPositionRight;
    }
}
