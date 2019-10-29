using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalShifter : MonoBehaviour
{

    public float rightLimit = 2.5f;
    public float leftLimit = -2.5f;
    public float speed = 1f;
    private int direction = 1;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
}

