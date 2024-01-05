using UnityEngine;

public class EnemyPatrol : MonoBehaviour
    {
    public Transform[] waypoints;
    public float speed = 2.0f;
    private int waypointIndex = 0;
    private float distToPoint;

    void Update()
        {
        Move();
        }

    void Move()
        {
        distToPoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (distToPoint < 1f)
            {
            IncreaseIndex();
            }

        Patrol();
        }

    void Patrol()
        {
        transform.LookAt(waypoints[waypointIndex].position);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
        }

    void IncreaseIndex()
        {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
            {
            waypointIndex = 0;
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
