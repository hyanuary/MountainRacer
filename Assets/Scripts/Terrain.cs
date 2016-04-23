using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {

    CarMovement car;

	// Use this for initialization
	void Start () {

        car = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMovement>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void decreasingSpeed (float accel)
    {
        accel = 0.0f;
        car.movementSpeed *= accel;
    }

    
}
