using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//libreria de carga de escenas 
using UnityEngine.SceneManagement;


public class aumentaryPasarNivel : MonoBehaviour
{

    //para el menu contador
    private int puntuacion;
    public TextMeshProUGUI puntuacionText;

    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Moneda")
        {
            puntuacion = puntuacion + 2;
            puntuacionText.text = "Puntaje: " + puntuacion.ToString();
        }

        //tarea3 O practica 3
        if (puntuacion >= 10)
        {
            SceneManager.LoadScene("WIN");
        }
    }

}
