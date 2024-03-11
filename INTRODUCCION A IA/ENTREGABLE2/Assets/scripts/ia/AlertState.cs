using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{
    public float speedRotate = 100f;
    public float searchDuration = 5f;
    public Color colorState = Color.yellow;
    private StateMachine stateMachine;
    private NavMeshController navMesController;
    private SightController sightController;
    private float searchTime;

    void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        navMesController = GetComponent<NavMeshController>();
        sightController = GetComponent<SightController>();
    }

    void OnEnable()
    {
        stateMachine.MeshRendererIndicator.material.color = colorState;
        navMesController.StopNavMeshAgent();
        searchTime = 0f;
    }

    void Update()
    {
        RaycastHit hit;
        if (sightController.canSeePlayer(out hit))
        {
            navMesController.followPlayer = hit.transform;
            stateMachine.ActiveState(stateMachine.persecutionState);
            return;
        }

        transform.Rotate(0f, searchDuration * Time.deltaTime, 0f);
        searchTime += Time.deltaTime;
        if (searchTime >= searchDuration)
        {
            stateMachine.ActiveState(stateMachine.patrolState);
            return;
        }
    }
}
