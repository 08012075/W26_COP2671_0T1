using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    public float speed = 3.0f;
    public float playerRange = 10.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Only lets ball roll towards player if players close enough
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < 5f) 
        {
            enemyRb.AddForce(lookDirection * speed);
        }
        
        // Destroys object after falling off map
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
