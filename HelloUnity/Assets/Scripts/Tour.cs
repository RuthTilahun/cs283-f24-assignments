using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour : MonoBehaviour
{
    public Transform[] POI;
    private int current = 0;
    public Transform startPos;
    public Transform endPos;
    private float u;
    public float duration = 3.0f;

    //time instance variable

    public Color startCol;
    public Color endCol;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            u = 0;
            //create a copy of the camera's current position
            startPos = new GameObject().transform;
            startPos.position = Camera.main.transform.position;
            startPos.rotation = Camera.main.transform.rotation;

            // The current camera position and rotation
            current = (current + 1) % POI.Length;  // Cycle through POIs
            endPos = POI[current];
        }
        if (startPos != null && endPos != null)
        {
           
            //lerp from 0 - 1
            u += Time.deltaTime/ duration;
            u = Mathf.Clamp01(u);
            Debug.Log("u" + u);
            //Debug.Log("time" + time);

            //time += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(startPos.position, endPos.position, u);
            Camera.main.transform.rotation = Quaternion.Slerp(startPos.rotation, endPos.rotation, u);
            if (u >= 1.0f)
            {
                startPos = null;
                endPos = null;
            }

        }
    }
}
