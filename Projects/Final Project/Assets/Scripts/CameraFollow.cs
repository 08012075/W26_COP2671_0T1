using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables for camera and player
    public GameObject player;
    public Transform focalPoint;
    private float offsetX = 0f;
    private float offsetY = 2f;
    private float offsetZ = -6f;
    private Vector3 offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = new Vector3(offsetX, offsetY, offsetZ);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Rotates offset by focal point rotation
        Vector3 rotateOffset = focalPoint.rotation * offset;

        // So camera follows player
        transform.position = player.transform.position + rotateOffset;
    }
}
