using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public SOEnemy enemy;
    public float stopDistance = 1f;
    public float chaseDistance = 2f;

    private Rigidbody2D rb;
    private bool isChasing = true;
    float distanceToPlayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
    }
    private void FixedUpdate()
    {
        if (isChasing)
        {
            if (distanceToPlayer > stopDistance)
            {
                ChasePlayer();
            }
            else
            {
                StopChasing();
            }
        }
        else
        {
            if (distanceToPlayer > chaseDistance)
            {
                StartChasing();
            }
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized.normalized;
        rb.MovePosition((Vector2)transform.position + (direction * enemy.speed * Time.fixedDeltaTime));
    }

    private void StopChasing()
    {
        isChasing = false;
    }

    private void StartChasing()
    {
        isChasing = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopChasing();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartChasing();
        }
    }
}