using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGame : MonoBehaviour
{
    public GameObject uiElement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(true);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
