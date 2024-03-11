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
    private SightController sightController;

    void Awake()
    {
        stateMachine= GetComponent<StateMachine>();
        navMeshController= GetComponent<NavMeshController>();
        sightController = GetComponent<SightController>();
    }

    void Update()
    {
        RaycastHit hit;
        if (sightController.canSeePlayer(out hit))
        {
            navMeshController.followPlayer = hit.transform;
            stateMachine.ActiveState(stateMachine.persecutionState);
            return;
        }

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

        int randomIndex = Random.Range(0, targetPoint.Length);
        navMeshController.UpdateDestinationPointNavMeshAgent(targetPoint[randomIndex].position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            stateMachine.ActiveState(stateMachine.alertState);
        }
    }

}
