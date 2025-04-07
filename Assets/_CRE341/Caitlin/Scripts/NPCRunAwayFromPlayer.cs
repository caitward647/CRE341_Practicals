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
    public Transform centrePoint;
    public int range;
    public Vector3 point;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npcRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
      ratBehaviour();
    }

    void ratBehaviour() //different method
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if ((distanceToPlayer < safeDistance))
        {
            RunAwayFromPlayer();

        }
        else
        {
            PatrolPoints();
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

    public void PatrolPoints()
    {
       if (agent.remainingDistance <= agent.stoppingDistance) //done with path
       {


            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.red, 1.0f); //gizmos
                agent.SetDestination(point);
            }
        }
    }
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        if (NavMesh.SamplePosition(center + Random.insideUnitSphere * range, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
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
                //agent.Warp(hit.position);
               //agent.SetDestination(hit.position);
            }
        }
    }
}
