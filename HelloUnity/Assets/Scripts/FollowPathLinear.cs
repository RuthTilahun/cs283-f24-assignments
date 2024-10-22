using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolowPathLinear : MonoBehaviour
{
    public Transform[] POI;
    private int current = -1;
    public Transform start;
    public Transform end;
    public float duration = 3.0F;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoLerp());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(DoLerp());
        }
    }

    IEnumerator DoLerp()
    {
        while (true)
        {
            start.position = transform.position;
            start.rotation = transform.rotation;

            // The current camera position and rotation
            current = (current + 1) % POI.Length;  // Cycle through POIs
            end = POI[current];
            for (float timer = 0; timer < duration; timer += Time.deltaTime)
            {
                float u = timer / duration;
                transform.position = Vector3.Lerp(start.position, end.position, u);
                transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, u);
                yield return null;
            }
            transform.position = end.position;
            transform.rotation = end.rotation;
        }
    }
}

