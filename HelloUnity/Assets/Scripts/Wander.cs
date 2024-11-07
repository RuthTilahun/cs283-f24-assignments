using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public float range;
    Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        RandomPoint(transform.position, range, out point);
        Debug.DrawRay(point, Vector3.forward, Color.black, 1.0f);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(point);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((point - transform.position).magnitude < 1.0f)
        {
            RandomPoint(transform.position, range, out point);
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(point);
        }
    }
}
