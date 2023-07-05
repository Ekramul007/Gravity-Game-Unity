using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerDuration = 120f; // Duration of the timer in seconds (2 minutes)
    public Text timerText; // Reference to the UI Text component
    private float timer = 0f;
    private bool isTimerRunning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                // Timer has reached zero
                StopTimer();
            }
        }
    }

    private void StartTimer()
    {
        isTimerRunning = true;
        timer = timerDuration;
        UpdateTimerText();
        Debug.Log("Timer started!");
    }

    private void StopTimer()
    {
        isTimerRunning = false;
        Debug.Log("Timer stopped!");
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = FormatTime(timer); // Display timer value in MM:SS format
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
