using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public float moveSpeed = 1;

    public GameObject explosion;
    public float playerRange = 10f;
    public Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            // Normalized will only take either x or y to multiply for the moveSpeed
            // this way the enemy won't be moving faster when is faraway and slow when it's close to us
            theRB.velocity = playerDirection.normalized * moveSpeed;
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
