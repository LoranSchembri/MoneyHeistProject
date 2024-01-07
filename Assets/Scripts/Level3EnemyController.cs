using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Level3EnemyController : MonoBehaviour
{
    public Transform helicopter; // Assign this in the Inspector
    private Animator animator;
    private NavMeshAgent agent;
    public float attackDistance = 2.0f; // Adjust this as needed
    public float idleDuration = 2.0f; // Duration of the idle animation
    private Vector3 targetPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(BeginMovementAfterIdle());
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target; // Set the target position
    }

    IEnumerator BeginMovementAfterIdle()
    {
        // Wait for the idle animation to finish
        yield return new WaitForSeconds(idleDuration);

        // Start moving towards the helicopter
        agent.SetDestination(helicopter.position);
        animator.SetBool("isRunning", true);
    }

    void Update()
    {
        float distanceToHelicopter = Vector3.Distance(transform.position, helicopter.position);

        if (distanceToHelicopter <= attackDistance)
        {
            if (!animator.GetBool("isPunching"))
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isPunching", true);
                agent.isStopped = true;
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punching")) // Check if in punch animation
                {
                    helicopter.GetComponent<HelicopterHealth>()?.TakeDamage(10f); // Damage amount
                }
            }
        }
        else
        {
            // Enemy is not close enough to attack
            if (!animator.GetBool("isRunning"))
            {
                animator.SetBool("isPunching", false);
                animator.SetBool("isRunning", true);
                agent.isStopped = false;
            }
        }
    }
}
