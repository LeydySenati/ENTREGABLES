using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTRUCCIONBULLET : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // Si la bala colisiona con algo que no sea el jugador
        if (!collision.gameObject.CompareTag("Player"))
        {
            // Destruir la bala
            Destroy(gameObject);
        }
    }
}