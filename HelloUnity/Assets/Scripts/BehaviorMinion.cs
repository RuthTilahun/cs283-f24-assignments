using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTAI;
using UnityEditor.Build;
using System;

public class BehaviorMinion : MonoBehaviour
{
    public Transform player;
    public Transform retreatDestination; //set to a sphere
    public Transform home;
    public GameObject weapon;
    public float rangeFromHome;
    public float rangeFromPlayer;
    private Root root = BT.Root();
    
    // Start is called before the first frame update
    void Start()
    {
        Selector selector = BT.Selector();
        Sequence sequence1 = BT.Sequence();
        Sequence sequence2 = BT.Sequence();
        Sequence sequence3 = BT.Sequence();
        root.OpenBranch(
            selector.OpenBranch(
                sequence1.OpenBranch(
                    BT.Condition(InAttackRange),
                    BT.RunCoroutine(AttackCoroutine)
                ),
            
                sequence2.OpenBranch(
                    BT.Condition(NearHome),
                    BT.RunCoroutine(RetreatCoroutine)
                ),
        
                sequence3.OpenBranch(
                    BT.Condition(OutOfRange), // out of attack range and home area
                    BT.RunCoroutine(FollowCoroutine)
                )

            )
        );

    }

    // Update is called once per frame
    void Update()
    {
        root.Tick();
    }

    bool InAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < rangeFromPlayer && !NearHome();
    }

    private bool NearHome()
    {
        return Vector3.Distance(player.position, home.position) < rangeFromHome;
    }

    bool OutOfRange()
    {
        return !InAttackRange() && !NearHome();
    }

    IEnumerator<BTState> AttackCoroutine()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(player.position);

        float waitTime = 3.0f;
        float next = 0f;

        while (InAttackRange())
        {
            agent.SetDestination(player.position);
            if (Time.time >= next)
            {
                Shoot();
                next = Time.time + waitTime;
            }
            yield return BTState.Continue;
        }
        yield return BTState.Success;
    }

    private void Shoot()
    {
        Vector3 startPosition = transform.position + transform.forward * 2.5f + Vector3.up * 2.0f;
        GameObject wp = Instantiate(weapon, startPosition, Quaternion.identity);
        Vector3 direction = (player.position - transform.position).normalized;
       
        Rigidbody rb = wp.GetComponent<Rigidbody>();

        if (rb != null)
            rb.velocity = direction * 20f;
    }

    IEnumerator<BTState> RetreatCoroutine()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(retreatDestination.position);
        yield return BTState.Success;
    }

    IEnumerator<BTState> FollowCoroutine()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.position);
        while (OutOfRange())
        {
            yield return BTState.Continue;
        }
        yield return BTState.Success;
    }
}


