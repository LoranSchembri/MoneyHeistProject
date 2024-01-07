using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    BoxCollider boxCollider;

    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;
    Animator animator;
    
    //State Change
    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (playerInAttackRange)
        {
            Attack();
        }
        else if (playerInSight)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 20) walkpointSet = false;
    }

    void Chase()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null)
        {
            agent.SetDestination(player.transform.position);
            Debug.Log("Chasing player at position: " + player.transform.position);
        }
        else
        {
            Debug.LogError("Player object not found for Chase.");
        }
    }


    void Attack()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null && animator.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
        }
        else if (player == null)
        {
            Debug.LogError("Player object not found for Attack.");
        }

    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint,Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int damageAmount = 10;

        var playerHealth = other.GetComponent<PlayerHealth>();
         
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Dealt " + damageAmount + " damage to the player.");
        }
    }
}
