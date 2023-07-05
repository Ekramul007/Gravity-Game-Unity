using UnityEngine;

public class Falling : MonoBehaviour
{
    public Animator animator;
    public bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            UpdateAnimator();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        if (animator != null)
        {
            animator.SetBool("isFalling", !isGrounded);
        }
    }
}
