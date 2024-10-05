using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float linearSpeed = 5.0f;
    public float turningSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * linearSpeed * Time.deltaTime,Space.World);
        }
        // Move backward
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * linearSpeed * Time.deltaTime,Space.World);
        }

        // Turn left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up * -turningSpeed * Time.deltaTime);
        }
        // Turn right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up * turningSpeed * Time.deltaTime);
        }
    }
}
