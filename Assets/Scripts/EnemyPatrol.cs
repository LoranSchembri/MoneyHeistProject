using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
    {
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 4.0f;
    public float detectionRange = 10.0f;

    private NavMeshAgent navMeshAgent;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private bool isChasing = false;
    private Transform player; // No longer assigned in the inspector

    private Vector3 lastPosition;
    private float stuckThreshold = 0.1f; // Distance to check if stuck
    private float checkStuckInterval = 2f; // Time interval to check if stuck
    private float stuckTimer = 0f;

    void Start()
        {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = patrolSpeed;

        GameObject[] waypointsObjects = GameObject.FindGameObjectsWithTag("Waypoints");
        waypoints = new Transform[waypointsObjects.Length];
        for (int i = 0; i < waypointsObjects.Length; i++)
            {
            waypoints[i] = waypointsObjects[i].transform;
            }

        SelectRandomWaypoint();
        lastPosition = transform.position;

        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player using tag
        }

    void Update()
        {
        if (isChasing)
            {
            navMeshAgent.SetDestination(player.position);
            }
        else
            {
            Patrol();
            }

        DetectPlayer();
        CheckIfStuck();
        }

    void Patrol()
        {
        if (navMeshAgent.remainingDistance < 1f)
            {
            SelectRandomWaypoint();
            }
        }

    void SelectRandomWaypoint()
        {
        if (waypoints.Length == 0) return;

        waypointIndex = Random.Range(0, waypoints.Length);
        navMeshAgent.SetDestination(waypoints[waypointIndex].position);
        }

    void DetectPlayer()
        {
        if (player != null)
            {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (distanceToPlayer < detectionRange)
                {
                isChasing = true;
                navMeshAgent.speed = chaseSpeed;
                }
            else
                {
                isChasing = false;
                navMeshAgent.speed = patrolSpeed;
                }
            }
        }

    void CheckIfStuck()
        {
        stuckTimer += Time.deltaTime;
        if (stuckTimer >= checkStuckInterval)
            {
            if (Vector3.Distance(transform.position, lastPosition) < stuckThreshold)
                {
                SelectRandomWaypoint();
                }
            lastPosition = transform.position;
            stuckTimer = 0f;
            }
        }

    void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Player"))
            {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                {
                playerHealth.TakeDamage(10);
                }
            }
        }
    }
