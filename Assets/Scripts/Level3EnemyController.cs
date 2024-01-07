using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Level3EnemyController : MonoBehaviour
{
    public Transform helicopter; // Helicopter target
    public Transform player; // Player target, assign this in the Inspector
    private Animator animator;
    private NavMeshAgent agent;
    public float attackDistance = 2.0f; // Adjust this as needed for helicopter
    public float chasePlayerDistance = 5.0f; // Distance to start chasing the player
    public float idleDuration = 2.0f; // Duration of the idle animation
    private Transform currentTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentTarget = helicopter; // Start with helicopter as the target
        StartCoroutine(BeginMovementAfterIdle());
    }

    IEnumerator BeginMovementAfterIdle()
    {
        yield return new WaitForSeconds(idleDuration);
        agent.SetDestination(currentTarget.position);
        animator.SetBool("isRunning", true);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceToHelicopter = Vector3.Distance(transform.position, helicopter.position);

        // Check if the player is within chase range
        if (distanceToPlayer <= chasePlayerDistance)
        {
            currentTarget = player;
        }
        else
        {
            currentTarget = helicopter;
        }

        // Move towards the current target
        agent.SetDestination(currentTarget.position);

        // Attack logic based on the current target
        float distanceToTarget = (currentTarget == helicopter) ? distanceToHelicopter : distanceToPlayer;
        if (distanceToTarget <= attackDistance)
        {
            if (!animator.GetBool("isPunching"))
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isPunching", true);
                agent.isStopped = true;

                if (currentTarget == helicopter && animator.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
                {
                    helicopter.GetComponent<HelicopterHealth>()?.TakeDamage(10f); // Damage amount
                }
            }
        }
        else
        {
            if (!animator.GetBool("isRunning"))
            {
                animator.SetBool("isPunching", false);
                animator.SetBool("isRunning", true);
                agent.isStopped = false;
            }
        }
    }
}
