using UnityEngine;

public class NPCRunAwayFromPlayer : MonoBehaviour
{
    public float runSpeed = 5f;
    public float safeDistance = 10f;

    private Transform player;
    private Rigidbody npcRigidbody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npcRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RunAwayFromPlayer();
    }

    void RunAwayFromPlayer()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < safeDistance)
        {
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;
            Vector3 newPosition = transform.position + directionAwayFromPlayer * runSpeed * Time.deltaTime;
            npcRigidbody.MovePosition(newPosition);
        }
    }
}
