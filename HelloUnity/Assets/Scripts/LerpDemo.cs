using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    float duration = 3.0f;

    public Transform startPos;
    public Transform endPos;

    public Color startCol;
    public Color endCol;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float u = Mathf.Repeat(Time.realtimeSinceStartup, duration) / duration;
        //float u = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup));
        Camera.main.transform.position = Vector3.Lerp(startPos.position, endPos.position, u);
        Camera.main.transform.rotation = Quaternion.Slerp(startPos.rotation, endPos.rotation, u);

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.color = Color.Lerp(startCol, endCol, u);
        }
    }
}

