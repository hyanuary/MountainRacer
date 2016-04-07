using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour {

    public float movementSpeed = 20.0f;
    public Rigidbody rb;
    public Slider acceleration;

    //Wheels
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider backLeft;
    public WheelCollider backRight;

    private float carAcceleration = 0f;

    // Use this for initialization
    void Start ()
    {
    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    void Movement ()
    {
        //Car acceleration == slider position, mvement speed increaments by carAcceleration
        carAcceleration = acceleration.value;
        movementSpeed += carAcceleration;

        //Apply force to rear wheels to simulate rear wheel drive
        backLeft.motorTorque = movementSpeed;
        backRight.motorTorque = movementSpeed;
        Debug.Log(movementSpeed);
    }
}