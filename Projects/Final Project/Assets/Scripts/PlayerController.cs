using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 6f;

    private AudioSource audioSource;
    public AudioClip playerImpact;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        // Adds audio source component
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Variables for forward, backward, and left and right movement
        float forwardInput = Input.GetAxis("Vertical");
        float leftRightInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput * 0.5f * Time.deltaTime);
        playerRb.AddForce(focalPoint.transform.right * speed * leftRightInput * 0.5f * Time.deltaTime);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Adds player impact sound when hitting anything
        if (!collision.gameObject.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(playerImpact);
        }
    }
}
