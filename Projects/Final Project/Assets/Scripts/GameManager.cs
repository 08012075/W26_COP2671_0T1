using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Timer variables
    private float timer;
    public TextMeshProUGUI timerText;
    public bool gameOver = false;

    // Scoreboard variables
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI powerupCountText;
    private int coinCount = 0;

    // Switch mechanic for powerup count
    public SwitchMechanic switchMechanic;

    // Title variables
    public GameObject titleScreen;
    public bool isGamePlaying = false;
    public AudioSource menuMusic;

    // Camera variables for menu
    public Camera menuCamera;
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 120f;
        titleScreen.SetActive(true);
        timerText.gameObject.SetActive(false);
        coinCountText.gameObject.SetActive(false);
        powerupCountText.gameObject.SetActive(false);
        menuMusic.Play();

        // Camera
        menuCamera.gameObject.SetActive(true);
        gameCamera.gameObject.SetActive(false);

        // Freezes game 
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePlaying && !gameOver) {
            UpdateTimer(Time.deltaTime);
            UpdatePowerupText();
        }
    }

    public void StartGame()
    {
        isGamePlaying = true;
        titleScreen.SetActive(false);
        timerText.gameObject.SetActive(true);
        coinCountText.gameObject.SetActive(true);
        powerupCountText.gameObject.SetActive(true);
        UpdateCoinText();

        // For game music
        switchMechanic.presentMusic.volume = 0.546f;
        menuMusic.Stop();

        // Enables game camera
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);

        // Unfreezes game
        Time.timeScale = 1;
    }

    // Method decreased timer each second
    private void UpdateTimer(float timerToDecrease)
    {
        timer -= timerToDecrease;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = "TIME: " + minutes + ":" + seconds.ToString("00");

        // If timer hits 0 game ends
        if (timer <= 0)
        {
            gameOver = true;
        }
    }

    // Adds coin to coin variable each time palyer collects one
    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText();
    }

    // So coins collected updates
    private void UpdateCoinText()
    {
        coinCountText.text = "RUPEES: " + coinCount;
    }

    // So powerups held updates
    private void UpdatePowerupText()
    {
        powerupCountText.text = "POWERUPS: " + switchMechanic.timelinePowerCount;
    }
}
