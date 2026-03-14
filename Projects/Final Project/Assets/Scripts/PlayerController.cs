using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Variables for forward, backward, and left and right movement
        float forwardInput = Input.GetAxis("Vertical");
        float leftRightInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput * 0.5f);
        playerRb.AddForce(focalPoint.transform.right * speed * leftRightInput * 0.5f);
    }
}
