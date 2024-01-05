using UnityEngine;

public class EnemyPatrol : MonoBehaviour
    {
    public float speed = 2.0f;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private float distToPoint;

    void Start()
        {
        // Find and assign waypoints tagged with "Waypoints"
        GameObject[] waypointsObjects = GameObject.FindGameObjectsWithTag("Waypoints");
        waypoints = new Transform[waypointsObjects.Length];
        for (int i = 0; i < waypointsObjects.Length; i++)
            {
            waypoints[i] = waypointsObjects[i].transform;
            }

        // Select a random initial waypoint
        waypointIndex = Random.Range(0, waypoints.Length);
        }

    void Update()
        {
        Move();
        }

    void Move()
        {
        if (waypoints.Length == 0) return;

        distToPoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (distToPoint < 1f)
            {
            SelectRandomWaypoint();
            }

        Patrol();
        }

    void Patrol()
        {
        transform.LookAt(waypoints[waypointIndex].position);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
        }

    void SelectRandomWaypoint()
        {
        int oldIndex = waypointIndex;
        while (waypointIndex == oldIndex) // Avoid selecting the same waypoint
            {
            waypointIndex = Random.Range(0, waypoints.Length);
            }
        }

    void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Player"))
            {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                {
                playerHealth.TakeDamage(10); // Damage value can be adjusted
                }
            }
        }
    }
