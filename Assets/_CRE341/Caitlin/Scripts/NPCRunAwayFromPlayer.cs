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
    // public float pauseTime = 2f;

    private float _wanderTimer;
    private bool _isWandering;

    //WanderAI WanderingNPC;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npcRigidbody = GetComponent<Rigidbody>();
<<<<<<< HEAD
        _isWandering = true;
=======

        //agent = GetComponent<NavMeshAgent>();
        //  _isWandering = true;

        //RunAwayFromPlayer();

     //   ratBehaviour();
>>>>>>> parent of 42bc172 (code)
    }

    void Update()
    {
     ratBehaviour();
    // RunAwayFromPlayer();

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
           // pauseAllMovement();
        }

    }

    void RunAwayFromPlayer()
    {
        //if (player == null) return;

       // float distanceToPlayer = Vector3.Distance(transform.position, player.position);



       // if (distanceToPlayer < safeDistance)
        {
          //  Debug.Log("Running away from player");
            // agent.enabled = false;
            // Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized; //finds distance

            //  Vector3 newPosition = transform.position + directionAwayFromPlayer * speed * Time.deltaTime;
            // npcRigidbody.MovePosition(newPosition);

            //rotating when being chased. Looks away from player
            // Quaternion targetRotation = Quaternion.LookRotation(directionAwayFromPlayer);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //creating different movement with slerp.

            // if (Vector3.Distance(transform.position, player.position) < safeDistance) //checking distance
            // {
            //     Vector3 directionToPlayer = (transform.position - player.position).normalized;
            // }

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
        //hate

      //  if (distanceToPlayer > safeDistance)
      //  {
          // Wander();
       // }

    }

    //wander
    public void Wander()
    {
            {
           // Debug.Log("Wandering");
            agent = GetComponent<NavMeshAgent>();
            //  agent.enabled = true;
            if (player == null) return;

         float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
            randomDirection += transform.position;

            NavMeshHit hit;
<<<<<<< HEAD
              if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
              {
                    
                    agent.SetDestination(hit.position);
              }
      }
=======
            if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
>>>>>>> parent of 42bc172 (code)
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
