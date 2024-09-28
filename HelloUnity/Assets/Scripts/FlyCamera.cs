using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlyCamera : MonoBehaviour
{
    public float lookSensitivity = 5.0f;
    public float rotationSpeed = 5.0f;
    public float fwdFactor = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //mouse movement to control the camera 
        Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")); //capture mouse movement
        Quaternion rotation = Camera.main.transform.rotation; //current rotation
        Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);

        //apply the rotation to transform the camera
        transform.rotation = horiz * rotation * vert;

        //Keyboard input to control the camera 
        {
            if (Input.GetKey(KeyCode.W))
                LookUp();
            else if (Input.GetKey(KeyCode.S))
                LookDown();
            else if (Input.GetKey(KeyCode.A))
                LookLeft();
            else if (Input.GetKey(KeyCode.D))
                LookRight();

            Vector3 fwd = Camera.main.transform.forward; //the direction the camera is facing
            Camera.main.transform.position += fwd * Input.mouseScrollDelta.y * fwdFactor; //move in the direction the camera is facing 

        }

        void LookUp()
        {
            transform.Rotate(Vector3.right * -rotationSpeed);

        }
        void LookDown()
        {
            // Rotate around the X-axis (local) in a positive direction to look down
            transform.Rotate(Vector3.right * rotationSpeed);
        }

        void LookLeft()
        {
            // Rotate around the Y-axis (global) in a negative direction to look left
            transform.Rotate(Vector3.up * -rotationSpeed, Space.World);
        }

        void LookRight()
        {
            // Rotate around the Y-axis (global) in a positive direction to look right
            transform.Rotate(Vector3.up * rotationSpeed, Space.World);
        }
    }
}
