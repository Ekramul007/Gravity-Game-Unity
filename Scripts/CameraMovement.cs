using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform  cameraTransform;
    public float RotateSpeed = 5f;

    private void FixedUpdate()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        cameraTransform.Rotate(Vector3.up, mouseY * RotateSpeed);
    }
}
