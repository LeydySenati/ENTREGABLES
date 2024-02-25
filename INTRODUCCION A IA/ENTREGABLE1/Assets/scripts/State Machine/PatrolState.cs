using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    public Transform[] targetPoint;
    public Color colorState = Color.green;
    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private int nextTargetPoint;

    void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
    }

    void Update()
    {

        if (navMeshController.HaveArrivedDestination())
        {
            nextTargetPoint = (nextTargetPoint + 1) %
          targetPoint.Length;
            UpdateTargetPointDestination();
        }
    }

    void OnEnable()
    {
        stateMachine.MeshRendererIndicator.material.color = colorState;
        UpdateTargetPointDestination();
    }

    void UpdateTargetPointDestination()
    {
        navMeshController.UpdateDestinationPointNavMeshAgent
        (targetPoint[nextTargetPoint].position);
    }

}
