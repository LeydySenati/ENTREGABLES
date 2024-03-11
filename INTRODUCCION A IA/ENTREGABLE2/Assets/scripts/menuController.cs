using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene("NIVEL1");
    }


    public void Salir()
    {
        Application.Quit();
    }


    //PRACTICA 3 
    public void Nivel2()
    {
        SceneManager.LoadScene("NIVEL2");
    }

    public void IRaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

