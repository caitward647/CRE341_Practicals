using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 10f;
   // public float pauseTime = 2f;

    private float _wanderTimer;
    private bool _isWandering;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _isWandering = true;
    }

    void Update()
    {
      if (_isWandering)
        {
            _wanderTimer += Time.deltaTime;

            if (_wanderTimer >= wanderInterval )
            {
           //  _wanderTimer = 0;
                Wander();
            }
        }
    }

    void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
