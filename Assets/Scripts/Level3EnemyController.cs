using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Level3EnemyController : MonoBehaviour
{
    public Transform helicopter; // Helicopter target
    public Transform player; // Player target, assign this in the Inspector
    private Animator animator;
    private NavMeshAgent agent;
    public float attackDistance = 3.0f; // Adjust this as needed for helicopter
    public float chasePlayerDistance = 5.0f; // Distance to start chasing the player
    private Transform currentTarget;
    public float idleDuration = 2.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentTarget = helicopter; // Start with helicopter as the target
        StartCoroutine(ActivateMovementAfterIdle());
    }

    IEnumerator ActivateMovementAfterIdle()
    {
        // Wait for the idle animation to finish
        yield return new WaitForSeconds(GetAnimationLength("Idle")); // Replace "Idle" with the name of your idle animation

        // Start moving towards the current target
        MoveTowardsTarget();
    }

    void Update()
    {
        // Update target based on player's proximity
        UpdateTarget();

        // Check and handle attack logic
        HandleAttack();
    }

    private void UpdateTarget()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        currentTarget = distanceToPlayer <= chasePlayerDistance ? player : helicopter;
    }

    private void MoveTowardsTarget()
    {
        agent.SetDestination(currentTarget.position);
        animator.SetBool("isRunning", true);
    }

    private void HandleAttack()
    {
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
        bool isAttacking = animator.GetBool("isPunching");

        if (distanceToTarget <= attackDistance && !isAttacking)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isPunching", true);
            agent.isStopped = true;
            ApplyDamageIfNeeded();
        }
        else if (distanceToTarget > attackDistance && isAttacking)
        {
            animator.SetBool("isPunching", false);
            animator.SetBool("isRunning", true);
            agent.isStopped = false;
        }
    }

    private void ApplyDamageIfNeeded()
    {
        if (currentTarget == helicopter && animator.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            helicopter.GetComponent<HelicopterHealth>()?.TakeDamage(10f);
        }
    }

    private float GetAnimationLength(string animationName)
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        foreach (AnimationClip clip in ac.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }
        return 0f;
    }
}
