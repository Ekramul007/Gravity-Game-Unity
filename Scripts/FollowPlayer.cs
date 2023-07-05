using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float followDistance = 3f;

    void Update()
    {
        // Calculate the target position with an offset distance
        Vector3 targetPosition = player.position + player.forward * followDistance;

        // Move the game object towards the target position smoothly
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }
}
