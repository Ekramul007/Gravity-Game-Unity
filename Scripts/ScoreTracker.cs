using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject); // Destroy the game object
        }
    }

    
}
