using UnityEngine;
using UnityEngine.AI;

public class EnemyLoitering : MonoBehaviour
    {
    public float patrolSpeed = 2.0f;

    private NavMeshAgent navMeshAgent;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private Animator animator;

    void Start()
        {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent != null)
            {
            navMeshAgent.enabled = true; // Ensure the NavMeshAgent is enabled
            navMeshAgent.speed = patrolSpeed;
            }

        GameObject[] waypointsObjects = GameObject.FindGameObjectsWithTag("Waypoints");
        waypoints = new Transform[waypointsObjects.Length];
        for (int i = 0; i < waypointsObjects.Length; i++)
            {
            waypoints[i] = waypointsObjects[i].transform;
            }

        SelectRandomWaypoint();
        }

    void Update()
        {
        Patrol();
        }

    void Patrol()
        {
        // Check if the enemy is close to the current waypoint
        if (navMeshAgent.remainingDistance < 1f && !navMeshAgent.pathPending)
            {
            // Select the next waypoint
            SelectRandomWaypoint();
            }

        // Check if the enemy is moving towards a waypoint
        if (navMeshAgent.remainingDistance > 1f || !navMeshAgent.isStopped)
            {
            // Start walk/run animation
            animator.SetBool("isRunning", true);
            }
        }


    void SelectRandomWaypoint()
        {
        if (waypoints.Length == 0) return;

        waypointIndex = Random.Range(0, waypoints.Length);
        navMeshAgent.SetDestination(waypoints[waypointIndex].position);
        }

    void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Player"))
            {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                {
                playerHealth.TakeDamage(10);
                animator.SetTrigger("isPunching"); // Play attack animation
                }
            }
        }
    }
