using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCRunAwayFromPlayer : MonoBehaviour
{
    public float speed = 30f;
    public float safeDistance;
    public float rotationSpeed = 20f;

    private Transform player;
    private Rigidbody npcRigidbody;

    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 10f;

    private float _wanderTimer;
    private bool _isWandering;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npcRigidbody = GetComponent<Rigidbody>();
        _isWandering = true;
    }

    void Update()
    {
     ratBehaviour();
    }

    void ratBehaviour() //different method
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if ((distanceToPlayer  < safeDistance))
        {
            RunAwayFromPlayer();
            
        }
        else if (_isWandering)
        {
            Wander();
        }
        else
        {
            pauseAllMovement();
        }

    }

    void RunAwayFromPlayer()
    {
        {
             Vector3 directionToPlayer = transform.position - player.position;
             Vector3 runTo = transform.position + directionToPlayer.normalized * safeDistance;

             NavMeshHit hit;
                if (NavMesh.SamplePosition(runTo, out hit, safeDistance, 1))
                {
                    agent.SetDestination(hit.position);
                }
        } 
    }

    //wander
    public void Wander()
    {
      {
       // Debug.Log("Wandering");
       agent = GetComponent<NavMeshAgent>();
       if (player == null) return;

             float distanceToPlayer = Vector3.Distance(transform.position, player.position);

             Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
             randomDirection += transform.position;

            NavMeshHit hit;
              if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
              {
                     agent.SetDestination(hit.position);
              }
      }
    }

    public void pauseAllMovement()
    {
        _isWandering = false;
        Debug.Log("pausedAllMovement");
        Rigidbody.Destroy(gameObject);
        speed = 0;
        gameObject.isStatic = true;
    }
}
