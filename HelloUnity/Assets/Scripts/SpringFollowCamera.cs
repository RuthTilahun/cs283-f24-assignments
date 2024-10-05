using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpringFollowCamera : MonoBehaviour
{
    public Transform target;
    public float hDist;
    public float vDist;
    public float dampConstant;
    public float springConstant;

    private Vector3 actualPosition;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        actualPosition = transform.position;
        hDist = 15.0f;
        vDist = 15.0f;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //camera position 
        Vector3 idealEye = target.position - (target.forward * hDist) + (target.up * vDist);

        //camera direction 
        Vector3 cameraForward = target.position - actualPosition;

        //compute the acceleration of the sprinf, then integrate
        Vector3 displacement = actualPosition - idealEye;
        Vector3 springAccel = (-springConstant * displacement) - (dampConstant * velocity);

        // Update the camera's velocity based on the spring acceleration
        velocity += springAccel * Time.deltaTime;
        actualPosition += velocity * Time.deltaTime;

        // Set the camera's position and rotation with the new values
        transform.position = actualPosition;
        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}
