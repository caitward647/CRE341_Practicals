using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.AI.Navigation;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEditor.ShaderGraph.Internal;
public class ItemGenerator : MonoBehaviour
{
   
    public GameObject itemPrefab , waypointsPrefab; // Reference to your item prefab
    public GameObject groundObject;

    [SerializeField] int numberOfItems = 5;
    [SerializeField] List<GameObject> items = new List<GameObject>();
    [SerializeField] int numberWaypoints = 4;
    [SerializeField] List<GameObject> waypoints = new List<GameObject>();

    [SerializeField] public NavMeshSurface surface;
    [SerializeField] private float raycastHeight = 50f; // Height above the plane from which to cast rays.
    [SerializeField] private int maxAttempts = 1000; // Safety limit to avoid an infinite loop.

    void Start()
    {
        if (groundObject == null)
        {
            Debug.LogError("No object tagged 'Ground' found. Make sure your ground plane is tagged correctly.");
            return;
        }

        surface.BuildNavMesh();

        
        SpawnWayPoints(numberWaypoints);
        SpawnItems(numberOfItems); //generate items into world
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            surface.BuildNavMesh();
        

            // delete existing items and spawn new ones
            GameObject[] go_items = GameObject.FindGameObjectsWithTag("Item");
            foreach (GameObject item in go_items) Destroy(item);


            GameObject[] go_wps = GameObject.FindGameObjectsWithTag("Waypoint");
            foreach (GameObject wp in go_wps) Destroy(wp);

            SpawnWayPoints(numberWaypoints);
            SpawnItems(numberOfItems);
        }
    }
    public Vector3 GetRandomGroundPoint()
    {
        Bounds groundBounds = groundObject.GetComponent<Renderer>().bounds;

        for (int i = 0; i < maxAttempts; i++)
        {
            // Pick a random position within the specified X-Z range, at a fixed height.
            float randX = Random.Range(groundBounds.min.x, groundBounds.max.x);
            float randZ = Random.Range(groundBounds.min.z, groundBounds.max.z);
            Vector3 origin = new Vector3(randX, raycastHeight, randZ);

            // Cast a ray straight down.
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, Mathf.Infinity))
            {
                // Check if the first hit collider is tagged "Ground".
                if (hit.collider.CompareTag("Ground"))
                {
                    return hit.point;
                }
            }
        }

        // If no suitable point is found after maxAttempts, return a default.
        Debug.LogWarning("No valid 'Ground' point found.");
        return Vector3.zero;
    }

    private void SpawnItems(int count)
    {
        int maxAttempts = 1000;
        for (int i = 0; i < count; i++)
        {
            Vector3 randomNPCPos = Vector3.zero;
            bool validPositionFound = false;
            int attempts = 0;

            while (!validPositionFound && attempts < maxAttempts)
            {
                randomNPCPos = GetRandomGroundPoint();
                if (randomNPCPos != Vector3.zero)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomNPCPos, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        randomNPCPos = hit.position;
                        validPositionFound = true;
                    }
                }
                attempts++;
            }

            if (validPositionFound)
            {
                Instantiate(itemPrefab, randomNPCPos, Quaternion.identity);
                // add the NPC to the list
                items.Add(itemPrefab);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid NavMesh point for NPC.");
            }
        }
    }



    private void SpawnWayPoints(int count)
    {

        for (int i = 0; i < count; i++)
        {
            Vector3 randomItems = Vector3.zero;
            bool validPositionFound = false;
            int attempts = 0;

            while (!validPositionFound && attempts < maxAttempts)
            {
                randomItems = GetRandomGroundPoint();
                if (randomItems != Vector3.zero)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomItems, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        randomItems = hit.position;
                        validPositionFound = true;
                    }
                }
                attempts++;
            }

            if (validPositionFound)
            {
                Instantiate(waypointsPrefab, randomItems, Quaternion.identity);
                // add the NPC to the list
                waypoints.Add(waypointsPrefab);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid NavMesh point for Waypoint.");
            }
        }
    }

}



