using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class VisualGhostAI : MonoBehaviour
{
    public enum State 
    {
        Wait,
        Patrol,
        Haunt
    }

    public State currentState = State.Patrol;
    public float closestDistance = .5f;

    public int waypointIndex = 0;
    public Transform patrolWaypoint;
    public Transform nextWaypoint;
    public Transform[] waypoints;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        nextWaypoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        { 
            case State.Patrol:
                // partol around house
                if (Vector3.Distance(transform.position, nextWaypoint.position) <= closestDistance)
                {
                    waypointIndex = waypointIndex + 1 >= waypoints.Length ? 0 : waypointIndex + 1; // prevent number from going passed size of array
                    nextWaypoint = waypoints[waypointIndex];
                }
                break;
            case State.Haunt:
                // do spookies

                // chase player
                PlayerMovement player = FindObjectOfType<PlayerMovement>();
                nextWaypoint = player.gameObject.transform;
                break;
            default:
                Debug.LogFormat("Unknown state: {}", currentState);
                break;
        }

        agent.destination = nextWaypoint.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player entered");
            patrolWaypoint = nextWaypoint;
            currentState = State.Haunt;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player exited");
            nextWaypoint = patrolWaypoint;
            currentState = State.Patrol;
        }
    }
}
