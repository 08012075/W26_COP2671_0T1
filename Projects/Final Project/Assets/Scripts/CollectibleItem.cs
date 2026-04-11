using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public AudioClip collectSound;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroys if player touches collectible object 
        if (other.CompareTag("Player"))
        {
            // Plays audio sound from player audio source
            AudioSource playerAudio = other.GetComponent<AudioSource>();
            if (playerAudio != null)
            {
                playerAudio.PlayOneShot(collectSound);
            }

            // Destroys gem after sound plays
           gameManager.AddCoin();
            Destroy(gameObject);
        }
    }
}
