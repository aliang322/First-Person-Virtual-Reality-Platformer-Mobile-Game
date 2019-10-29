using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    public float minXBounds = -27f;
    public float maxXBounds = 27f;
    public float walkSpeed = 0.8f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Camera.main.transform.rotation.x >= 0.01*minXBounds &&
           Camera.main.transform.rotation.x <= 0.01*maxXBounds)
        {
            Debug.Log("Positive X: " + 10*Camera.main.transform.rotation.x);
            Debug.Log("Negative X: " + 10*returnNegativeX(Camera.main.transform.rotation.x));
            float yVal = transform.position.y;
            transform.position = transform.position + Camera.main.transform.forward * walkSpeed;
            transform.position = new Vector3(transform.position.x, yVal, transform.position.z);
        }
    }

    private float returnNegativeX(float xValue)
    {
        float angle = xValue;
        angle = (angle > 180) ? angle - 360 : angle;
        return angle;
    }
}
