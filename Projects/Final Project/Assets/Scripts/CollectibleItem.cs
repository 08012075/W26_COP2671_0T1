using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public AudioClip collectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
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
            Destroy(gameObject);
        }
    }
}
