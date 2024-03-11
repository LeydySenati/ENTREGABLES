using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionState : MonoBehaviour
{
    public Color colorState = Color.red;
    private NavMeshController navMeshController;
    private SightController sightController;
    private StateMachine stateMachine;

    void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
        sightController = GetComponent<SightController>();
        stateMachine = GetComponent<StateMachine>();
    }

    void OnEnable()
    {
        stateMachine.MeshRendererIndicator.material.color = colorState;

    }

    void Update()
    {
        RaycastHit hit;
        if (!sightController.canSeePlayer(out hit, true))
        {
            stateMachine.ActiveState(stateMachine.alertState);
            return;
        }

        navMeshController.UpdateDestinationPointNavMeshAgent();
    }
}
