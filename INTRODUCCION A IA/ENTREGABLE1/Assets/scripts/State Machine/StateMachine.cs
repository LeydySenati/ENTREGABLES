using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public MonoBehaviour patrolState;
    public MonoBehaviour alertState;
    public MonoBehaviour persecutionState;
    public MonoBehaviour initialState;
    public MeshRenderer MeshRendererIndicator;
    private MonoBehaviour actualState;

    void Start()
    {
        ActiveState(initialState);
    }

    public void ActiveState(MonoBehaviour newState)
    {
        if (actualState != null) actualState.enabled = false;
        actualState = newState;
        actualState.enabled = true;

    }
}
