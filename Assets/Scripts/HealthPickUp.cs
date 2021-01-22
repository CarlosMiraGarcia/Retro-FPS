using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthAmmount = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if object colliding has the tag "Player"
        if (other.tag == "Player")
        {
            PlayerController.instance.AddHealth(healthAmmount);
            Destroy(gameObject);
        }
    }
}
