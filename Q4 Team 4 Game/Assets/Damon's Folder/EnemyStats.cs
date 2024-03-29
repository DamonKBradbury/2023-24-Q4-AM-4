using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    public NavMeshAgent enemy;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkRange;

    public float attackTime;
    bool attacked;
    public int maxHealth;
    public int health;
    public int baseDamage;
    public int damageDealing;

    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;
    public bool hasEatenJFruit;
    public bool hasEatenGFruit;
    public bool hasEatenFFruit;
    public bool hasEatenAGFruit;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); 
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSight && !playerInAttackRange) Patroling();
        if (playerInSight && !playerInAttackRange) ChasePlayer();
        if (playerInSight && playerInAttackRange) Attacking();
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            enemy.SetDestination(walkPoint);

        Vector2 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkRange, walkRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.y);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
       
    }

    private void ChasePlayer()
    {
        enemy.SetDestination(player.position);
    }

    private void Attacking()
    {
        enemy.SetDestination(transform.position);

        transform.LookAt(player);

        if (!attacked)
        {
            DealDamage();
            attacked = true;
            Invoke(nameof(ResetAttack), attackTime);
        }
    }
    private void ResetAttack()
    {
        attacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            DestroyEnemy();
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public void DealDamage()
    {
        player.GetComponent<PlayerStats>().health -= damageDealing;
    }
}
