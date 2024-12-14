using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BTAI;
using System;

public class BahaviorUnique : MonoBehaviour
{
    public Transform NPCEnemy;
    public Transform player;
    public Transform playerHome;
    public GameObject weapon;
    public float rangeFromHome;
    public float rangeFromPlayer;
    private Root root = BT.Root();

    // Start is called before the first frame update
    void Start()
    {
        Selector selector = BT.Selector();
        Sequence sequence = BT.Sequence();
        // go after the enemy and attack if the enemy is attacking the player
        root.OpenBranch(
           selector.OpenBranch(
               sequence.OpenBranch(
                   BT.Condition(InAttackRange),
                   BT.RunCoroutine(AttackCoroutine)
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
        return Vector3.Distance(NPCEnemy.position, player.position) < rangeFromPlayer && !NearHome();
    }

    private bool NearHome()
    {
        return Vector3.Distance(player.position, playerHome.position) < rangeFromHome;
    }

    IEnumerator<BTState> AttackCoroutine()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(NPCEnemy.position);

        float waitTime = 4.0f;
        float next = 0f;
        while (InAttackRange())
        {
            agent.SetDestination(NPCEnemy.position);
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
        Vector3 direction = (NPCEnemy.position - transform.position).normalized;

        Rigidbody rb = wp.GetComponent<Rigidbody>();

        if (rb != null)
            rb.velocity = direction * 20f;
    }
}
