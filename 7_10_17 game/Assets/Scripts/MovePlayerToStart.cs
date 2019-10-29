using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToStart : MonoBehaviour
{
    private Quaternion initialRotation;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y + 12f);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -30f)
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"),
                                            PlayerPrefs.GetFloat("PlayerY"),
                                            PlayerPrefs.GetFloat("PlayerZ"));
            transform.rotation = initialRotation;
        }
    }
}
