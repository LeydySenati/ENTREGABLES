using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightController : MonoBehaviour
{
    public Transform Eyes;
    public float visionRange = 30f;
    public Vector3 offset = new Vector3(0f, 0.75f, 0f);

    private NavMeshController navMeshController;

    void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
    }

    public bool canSeePlayer(out RaycastHit hit, bool seeToPlayer = false)
    {
        Vector3 vectorDirection;
        if (seeToPlayer)
        {
            vectorDirection = (navMeshController.followPlayer.position + offset) - Eyes.position;
        }
        else
        {
            vectorDirection = Eyes.forward;
        }

        return Physics.Raycast(Eyes.position, vectorDirection, out hit, visionRange) && hit.collider.CompareTag("Player");
    }
}
