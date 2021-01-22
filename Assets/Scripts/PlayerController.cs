using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    private Vector2 moveInput;
    private Vector2 mouseInput;
    public Rigidbody2D theRB;
    public float moveSpeed = 5;
    public float mouseSensitivity = 1f;
    public Camera viewCam;
    public GameObject bulletImpact;
    public int currentAmmo;

    // As soon as the game starts, we set the instance for all PlayerController script
    // to be the same for all
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement with Keyboard
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * - moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        // Player View Control using Mouse
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        // Quaternion is what is it used to perform a rotation (X, Y, Z and W). Euler converts it to a 3 values (X, Y, Z). 
        // We leave x and y the same, since they are just indicating movements to left, right, forward and backwards, but we change 
        // the z value, since it indicates rotation. We just take the value of mouseInput to said z value
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        // We use local because we only want to change the local rotation, which is just the main camera values.
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

        // shooting area
        if(Input.GetMouseButtonDown(0))
        {
            if(currentAmmo > 0)
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                // Here we check if we hit something (if it's true), do something.
                // We also out the value as the variable RaycastHit hit
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("I'm looking at " + hit.transform.name);
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                }

                else
                {
                    Debug.Log("I'm lookit at nothing");
                }

                currentAmmo--;
            }

            else
            {
                Debug.Log("No ammo left");
            }
        }
    }
}
