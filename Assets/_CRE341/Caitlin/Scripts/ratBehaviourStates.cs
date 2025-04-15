using UnityEngine;
using UnityEngine.AI;

public class ratBehaviourStates : MonoBehaviour
{
    public float speed = 30f;
    public float safeDistance;
    public float rotationSpeed = 20f;

    private Transform player;
    private Rigidbody npcRigidbody;


    //[Header("Animation Name")]
    //[SerializeField] private string deadAnimationName = "RATDEAD";
    //[SerializeField] private string idleAnimationName = "RatIdle";

    private Animator npc1;
    private bool isDead;

    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 10f;
    
    // private float _wanderTimer;
    //private bool _isWandering;
    public Transform centrePoint;
    public int range;
    public Vector3 point;

    public Animator animator;
   // private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npcRigidbody = GetComponent<Rigidbody>();
        isDead = false;
       // npc1 = gameObject.GetComponent<Animator>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
      //  rb.linearVelocity = transform.forward;
        animator.enabled = false;

        if (!isDead)
        {
        //   Debug.Log("Rat");
            RatBehaviour();
        }
    }

    void RatBehaviour() //different method
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if ((distanceToPlayer < safeDistance))
        {
            RunAwayFromPlayer();
        }
        if (isDead)
        {
            RatDead();
        }
        else
        {
            RatWander();
        }

    }
    public void RatDead()
    {
         npcRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        //npc1.Play(deadAnimationName, 0, 0.0f);
        //agent.isStopped = true;
        // npc1.Play();
        animator.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CageFloor")
        {
         //Debug.Log("ratdead");
            isDead = true;
            agent.isStopped = true;
        }
    }

    public void RunAwayFromPlayer()
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

    public void RatWander()
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

    private void OnCollisionEnter(Collision collision) //this is supposed to stop rats from getting stuck running into cages and keys.
    {
        if (collision.gameObject.CompareTag("interactiveObject")|| collision.gameObject.CompareTag("Cage"))
        {
           // Debug.Log("RAT HITS CAGE OR KEY");
            transform.rotation = Quaternion.LookRotation(transform.forward * -1); //Rat turns around when collides with key or cage
        }
    }
}
