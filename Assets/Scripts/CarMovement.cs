using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour {

    public float movementSpeed = 20.0f;
    public float declerationRate = 10.0f;
    public Slider acceleration;
    UIManager ui;



    //Wheels
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider backLeft;
    public WheelCollider backRight;

    // wheel detction 
    public WheelHit wheelL;
    public WheelHit wheelR;

    // Use this for initialization
    void Start ()
    {
        ui = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameLevel");
            acceleration.value = 0;
            movementSpeed = 0;
        }

        
    }

    void FixedUpdate ()
    {
        Movement();

        // left wheel detection
        backLeft.GetGroundHit(out wheelL);
        backRight.GetGroundHit(out wheelR);

        // end line detection
        if(wheelL.collider.gameObject.tag == "Finish")
        {
            movementSpeed = 0.0f;
            acceleration.value = 0.0f;
            ui.timerCheck = false;
        }

        //check point 
        if(wheelL.collider.gameObject.tag == "Check")
        {
            ui.checkPointCheck = true;
        }

        // grass terrain
        if (wheelL.collider.gameObject.tag == "Grass" && acceleration.value > 3.0f)
        {
            WheelFrictionCurve fwdF;
            fwdF = backLeft.forwardFriction;
            fwdF.extremumSlip = 0.9f;
            fwdF.extremumValue = 10.0f;
            fwdF.asymptoteSlip = 1.8f;
            fwdF.asymptoteValue = 20.0f;
            backLeft.forwardFriction = fwdF;

           
        }
       if (wheelR.collider.gameObject.tag == "Grass" && acceleration.value > 3.0f)
        {
            WheelFrictionCurve fwdF;
            fwdF = backRight.forwardFriction;
            fwdF.extremumSlip = 0.9f;
            fwdF.extremumValue = 10.0f;
            fwdF.asymptoteSlip = 1.8f;
            fwdF.asymptoteValue = 20.0f;
            backRight.forwardFriction = fwdF;
        }

        //asphalt terrain
        if (wheelL.collider.gameObject.tag == "Asphalt" && acceleration.value > 4.0f)
        {
            WheelFrictionCurve fwdF;
            fwdF = backLeft.forwardFriction;
            fwdF.extremumSlip = 0.9f;
            fwdF.extremumValue = 10.0f;
            fwdF.asymptoteSlip = 1.8f;
            fwdF.asymptoteValue = 20.0f;
            backLeft.forwardFriction = fwdF;


        }
        if (wheelR.collider.gameObject.tag == "Asphalt" && acceleration.value > 4.0f)
        {
            WheelFrictionCurve fwdF;
            fwdF = backRight.forwardFriction;
            fwdF.extremumSlip = 0.9f;
            fwdF.extremumValue = 10.0f;
            fwdF.asymptoteSlip = 1.8f;
            fwdF.asymptoteValue = 20.0f;
            backRight.forwardFriction = fwdF;
        }

        //dirt terrain
        if (wheelL.collider.gameObject.tag == "Dirt" && acceleration.value > 2.0f)
        {
            WheelFrictionCurve fwdF;
            fwdF = backLeft.forwardFriction;
            fwdF.extremumSlip = 0.9f;
            fwdF.extremumValue = 10.0f;
            fwdF.asymptoteSlip = 1.8f;
            fwdF.asymptoteValue = 20.0f;
            backLeft.forwardFriction = fwdF;


        }
        if (wheelR.collider.gameObject.tag == "Dirt" && acceleration.value > 2.0f)
        {
            WheelFrictionCurve fwdF;
            fwdF = backRight.forwardFriction;
            fwdF.extremumSlip = 0.9f;
            fwdF.extremumValue = 10.0f;
            fwdF.asymptoteSlip = 1.8f;
            fwdF.asymptoteValue = 20.0f;
            backRight.forwardFriction = fwdF;
        }
    }

    void Movement ()
    {
        movementSpeed += acceleration.value;

        //Apply force to rear wheels to simulate rear wheel drive
        backLeft.motorTorque = Mathf.Clamp(movementSpeed, 0.0f, 500.0f) * Time.deltaTime;
        backRight.motorTorque = Mathf.Clamp(movementSpeed, 0.0f, 500.0f) * Time.deltaTime;

        if (acceleration.value <= 0 && movementSpeed > 0)
        {
            movementSpeed -= declerationRate;
        }
    }

  /* void OnCollisionEnter (Collision terrain)
    {
        if (terrain.gameObject.tag == "Grass")
        {
            acceleration.value = 0;
            movementSpeed = 0;
        }
    }

    void OnCollisionStay (Collision terrain)
    {
        if (terrain.gameObject.tag == "Grass")
        {
            acceleration.maxValue = 0;
            movementSpeed = 0;
            terrain.transform.GetComponent<Terrain>().decreasingSpeed(movementSpeed);
        }
    }*/

    /*void GetGroundHit (WheelHit hit)
    {
        if(hit.collider.tag == "Grass")
        {
            acceleration.value = 0.0f;
            movementSpeed = 0.0f;
            Debug.Log("Hit");
        }
    }*/
}