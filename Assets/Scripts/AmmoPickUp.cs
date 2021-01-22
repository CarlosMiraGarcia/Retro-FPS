using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public int ammoAmmount = 25;
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
        if(other.tag == "Player")
        {
            PlayerController.instance.currentAmmo += ammoAmmount;
            Destroy(gameObject);
        }
    }
}
