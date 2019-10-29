using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalShifter : MonoBehaviour
{

    public float upperLimit = 10f;
    public float lowerLimit = -2.5f;
    public float speed = 8f;
    private int direction = 1;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y > upperLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < lowerLimit)
        {
            direction = 1;
        }
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
    }
}
