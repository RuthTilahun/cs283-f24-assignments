using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
    public Transform target;
    public Transform joint;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 r = (target.position - joint.parent.position);

        Vector3 e = joint.forward;

        //Compute the axis of rotation 
        Vector3 axisOfRotation = Vector3.Cross(r, e).normalized;

        //Compute the angle of rotation
        float phi = Mathf.Atan2(Vector3.Cross(r, e).magnitude, Vector3.Dot(r, r) + Vector3.Dot(r, e)) * Mathf.Rad2Deg;

        

        //Compute final rotation
        Quaternion rotation = Quaternion.AngleAxis(phi, axisOfRotation);

        //Apply rotation to the parent joint
        //joint.parent.rotation = rotation * phi;
        joint.parent.rotation = Quaternion.Slerp(joint.parent.rotation, rotation * joint.parent.rotation, Time.deltaTime * 5f);

        Debug.DrawLine(target.position,joint.parent.position,Color.black);
    }
}
