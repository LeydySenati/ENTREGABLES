using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dAÑOeNEMIGO : MonoBehaviour
{
    public int hitsToDestroy = 5; // Número de golpes para destruir al enemigo
    private int currentHits = 0; // Contador de golpes


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            currentHits++;
            if (currentHits >= hitsToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}

