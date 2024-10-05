using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidFollowCamera : MonoBehaviour
{
    public float hDist;
    public float vDist;
    public Transform target;
 

    // Start is called before the first frame update
    void Start()
    {
        hDist = 10.0f;
        vDist = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    void LateUpdate()
    {
       
        //camera position
        Vector3 eye = target.position - (target.forward * hDist)+ (target.up * vDist);

        //Direction of the camera
        Vector3 cameraForward = target.position - eye;

        // Set the camera's position and rotation with the new values
        // This code assumes that this code runs in a script attached to the camera
        transform.position = eye;
        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}
