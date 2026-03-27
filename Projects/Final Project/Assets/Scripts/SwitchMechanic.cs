using Mono.Cecil.Cil;
using UnityEngine;

public class SwitchMechanic : MonoBehaviour
{
    // Variables for present and future objects, inpresent bool, and timeline powerup count
    public GameObject presentTime;
    public GameObject futureTime;
    public Transform presentSpawnPos;
    public Transform futureSpawnPos;
    public Material presentSkybox;
    public Material futureSkybox;
    public int timelinePowerCount = 0;
    private bool inPresent = true;
    public AudioSource presentMusic;
    public AudioSource futureMusic;
    public AudioClip powerUpCollectSound;
    public AudioClip powerUpUseSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Starts with present music volume playing
        presentMusic.volume = 0.65f;
        futureMusic.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses t and also has at least one power up
        if (Input.GetKeyDown(KeyCode.T) && timelinePowerCount > 0)
        {
            // Plays powerup sound from player audio source
            AudioSource playerAudio = GetComponent<AudioSource>();
            if (playerAudio != null)
            {
                playerAudio.PlayOneShot(powerUpUseSound);
            }

            SwitchTimeline();
            timelinePowerCount--;
        }
    }

    void SwitchTimeline()
    {
        Vector3 timeSpawnPos;

        // If players in present and presses T it switches to future or present platforms and skybox. Also spawns player in each timeline spawn point
        if (inPresent)
        {
            presentTime.SetActive(false);
            futureTime.SetActive(true);

            // So evverytime player switches timelines they are in same spot in present or future
            timeSpawnPos = new Vector3(transform.position.x, futureSpawnPos.position.y, transform.position.z);
            transform.position = timeSpawnPos;

            // Changes skybox for future
            RenderSettings.skybox = futureSkybox;

            // Changes future music volume 
            presentMusic.volume = 0f;
            futureMusic.volume = 0.65f;
        }
        else
        {
            futureTime.SetActive(false);
            presentTime.SetActive(true);

            // So evverytime player switches timelines they are in same spot in present or future
            timeSpawnPos = new Vector3(transform.position.x, presentSpawnPos.position.y, transform.position.z);
            transform.position = timeSpawnPos;

            // Changes skybox for present
            RenderSettings.skybox = presentSkybox;

            // Changes present music volume 
            presentMusic.volume = 0.65f;
            futureMusic.volume = 0f;
        }

        // Switches inPresent to either false or true depending on what timeline
        inPresent = !inPresent;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroys powerup object once player grabs it
        if (other.CompareTag("TimePower"))
        {
            // Plays powerup sound from player audio source
            AudioSource playerAudio = GetComponent<AudioSource>();
            if (playerAudio != null)
            {
                playerAudio.PlayOneShot(powerUpCollectSound);
            }

            timelinePowerCount++;
            Destroy(other.gameObject);
        }
    }
}
