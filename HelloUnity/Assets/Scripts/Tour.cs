using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour : MonoBehaviour
{
    public float duration = 3.0f;
    public Transform[] POI;
    private int current = 0;
    public Transform startPos;
    public Transform endPos;

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
            startPos = Camera.main.transform;  // The current camera position and rotation
            current = (current + 1) % POI.Length;  // Cycle through POIs
            endPos = POI[current];
        }
        if (startPos != null && endPos != null)
        {
            float u = Mathf.Repeat(Time.realtimeSinceStartup, duration) / duration;
            Camera.main.transform.position = Vector3.Lerp(startPos.position, endPos.position, u);
            Camera.main.transform.rotation = Quaternion.Slerp(startPos.rotation, endPos.rotation, u);

            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.color = Color.Lerp(startCol, endCol, u);
            }
        }
               
    }
}
