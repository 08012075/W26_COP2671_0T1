using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Variables
    public float rotationSpeed = 100f;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // When player presses q moves camera left
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // When player presses e moves camera right
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        } 
    }
}
