using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour {

    public float movementSpeed = 20.0f;
    public Rigidbody rb;
    public Slider acceleration;
    public Camera mainCamera;

    private float carAcceleration = 0f;
    //private float surfaceAsphalt = 0.9f;
    //private float surfaceGrass = 0.3f;
    //private GameObject asphalt;
    //private GameObject grass;

    // Use this for initialization
    void Start ()
    {
    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        rb.AddForce(Vector3.left * movementSpeed * Time.deltaTime);
        Debug.Log(movementSpeed);
    }

    void Movement ()
    {
        carAcceleration = acceleration.value;
        movementSpeed += carAcceleration;
    }
}