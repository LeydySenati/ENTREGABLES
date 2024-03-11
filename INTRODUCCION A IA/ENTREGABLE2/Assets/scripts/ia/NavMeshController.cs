using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [HideInInspector]
    public Transform followPlayer;
    private NavMeshAgent navMeshAgent;
    public float fuerzaSalto = 5.0f;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void UpdateDestinationPointNavMeshAgent(Vector3 destinationPoint)
    {
        navMeshAgent.destination = destinationPoint;
        navMeshAgent.isStopped = false;
    }

    public void UpdateDestinationPointNavMeshAgent()
    {
        UpdateDestinationPointNavMeshAgent(followPlayer.position);
    }

    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public bool HaveArrivedDestination()
    {
        return navMeshAgent.remainingDistance <=
        navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

}
