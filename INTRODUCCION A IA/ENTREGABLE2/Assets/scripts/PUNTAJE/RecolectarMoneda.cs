using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarMoneda : MonoBehaviour
{

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            Destroy(gameObject);
        }
    }
}
