using UnityEngine;

public class CollectibleItem : MonoBehaviour
{

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
            Destroy(gameObject);
        }
    }
}
