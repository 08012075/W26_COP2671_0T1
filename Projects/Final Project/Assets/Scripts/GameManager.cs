using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Text UI variables
    private float timer;
    public TextMeshProUGUI timerText;
    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 121;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer(Time.deltaTime);
    }

    // Method decreased timer each second
    private void UpdateTimer(float timerToDecrease)
    {
        // If game timer still has time it keeps decreasing
        if (!gameOver) { 
            timer -= timerToDecrease;
            timerText.text = "Time: " + (int)timer;

            // If timer hits 0 game ends
            if (timer <= 0)
            {
                gameOver = true;
            }
        }
    }
}
