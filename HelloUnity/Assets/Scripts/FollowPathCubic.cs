using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathCubic : MonoBehaviour
{
        
    public Transform[] controlPoints;
    public bool useDeCasteljau = false; 

    private int currentSegment = 0;
    public float duration = 3.0F;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(FollowPath()); 
    }

    // Update is called once per frame
    void Update()
    {
    } 


    // Coroutine to move along the curve
    IEnumerator FollowPath()
    {
        for (int i = 1; i < controlPoints.Length; i++)
        {

            Vector3 b0 = controlPoints[i - 1].position; // b0 = pi−1
            Vector3 b3 = controlPoints[i].position;     // b3 = pi

            Vector3 b1, b2;

            // Compute b1 and b2 based on the segment
            if (i == 1) // First segment
            {
                b1 = b0 + (1.0f / 6.0f) * (b3 - b0); // Special case for first segment
            }
            else
            {
                b1 = b0 + (1.0f / 6.0f) * (controlPoints[i].position - controlPoints[i - 2].position);
            }

            if (i == controlPoints.Length - 1) // Last segment
            {
                b2 = b3 - (1.0f / 6.0f) * (b3 - b0); // Special case for last segment
            }
            else
            {
                b2 = b3 - (1.0f / 6.0f) * (controlPoints[i + 1].position - controlPoints[i - 1].position);
            }

            // Move along the cubic Bezier curve for the current segment
            for (float timer = 0; timer < duration; timer += Time.deltaTime)
            {
                float u = timer / duration;
                Vector3 position;

                if (useDeCasteljau)
                {
                    // Use De Casteljau's algorithm 
                    position = DeCasteljau(b0, b1, b2, b3, u);
                }
                else
                {
                    // Use the Bezier polynomial formula 
                    position = Bezier(b0, b1, b2, b3, u);
                }

                // update the rotation
                Vector3 direction = (position - transform.position).normalized;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), u);

                // Move the character to the new position
                transform.position = position;

                yield return null;
            }
        }
    }

    // Polynomial formula for cubic Bezier curve
    Vector3 Bezier(Vector3 b0, Vector3 b1, Vector3 b2, Vector3 b3, float t)
    {
        float u = 1 - t;
        return u * u * u * b0 + 3 * u * u * t * b1+ 3 * u * t * t * b2 + t * t * t * b3;
    }

    // De Casteljau's algorithm for cubic Bezier curve
    Vector3 DeCasteljau(Vector3 b0, Vector3 b1, Vector3 b2, Vector3 b3, float t)
    {
        // First interpolation
        Vector3 p0 = Vector3.Lerp(b0, b1, t);
        Vector3 p1 = Vector3.Lerp(b1, b2, t);
        Vector3 p2 = Vector3.Lerp(b2, b3, t);

        // Second interpolation
        Vector3 q0 = Vector3.Lerp(p0, p1, t);
        Vector3 q1 = Vector3.Lerp(p1, p2, t);

        // Final interpolation
        return Vector3.Lerp(q0, q1, t);
    }

    
}
