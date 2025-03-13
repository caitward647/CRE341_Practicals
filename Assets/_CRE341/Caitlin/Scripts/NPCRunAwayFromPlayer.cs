using UnityEngine;
using UnityEngine.AI;

public class NPCRunAwayFromPlayer : MonoBehaviour
{
    public float speed = 30f;
    public float safeDistance = 8f;
    public float rotationSpeed = 20f;

    private Transform player;
    private Rigidbody npcRigidbody;

    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 10f;
    // public float pauseTime = 2f;

    private float _wanderTimer;
    private bool _isWandering;

    //WanderAI WanderingNPC;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npcRigidbody = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        //  _isWandering = true;

        //RunAwayFromPlayer();
    }

    void Update()
    {
     RunAwayFromPlayer();

       //if (_isWandering)
        //{
          //  _wanderTimer += Time.deltaTime;

          //  if (_wanderTimer >= wanderInterval)
          //  {
                //  _wanderTimer = 0;
            //    Wander();
           // }
       // }
    }

    void RunAwayFromPlayer()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < safeDistance)
        {
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized; //finds distance

            Vector3 newPosition = transform.position + directionAwayFromPlayer * speed * Time.deltaTime;
            npcRigidbody.MovePosition(newPosition);

            //rotating when being chased. Looks away from player
            Quaternion targetRotation = Quaternion.LookRotation(directionAwayFromPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
    }

    void Wander()
    {
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
