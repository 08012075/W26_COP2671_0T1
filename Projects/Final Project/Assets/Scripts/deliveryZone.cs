using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deliveryZone : MonoBehaviour
{
    // Variables
    public GameManager gameManager;
    public GameObject gameComplete;
    public TextMeshProUGUI warningText;
    public Transform notEnoughCoinSpawn;
    public int requiredCoin = 10;

    // Camera variables
    public Camera menuCamera;
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameComplete.SetActive(false);
        warningText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.coinCount >= requiredCoin)
            {
                Time.timeScale = 0;
                gameComplete.SetActive(true);
                menuCamera.gameObject.SetActive(true);
                gameCamera.gameObject.SetActive(false);
            }
            else
            {
                other.transform.position = notEnoughCoinSpawn.position;
                StartCoroutine(ShowWarningText());
            }
        }
    }

    IEnumerator ShowWarningText()
    {
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningText.gameObject.SetActive(false);
    }
}
