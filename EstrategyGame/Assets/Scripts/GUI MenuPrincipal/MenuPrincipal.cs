
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Playing");
    }

    public void Salir()
    {
        Debug.Log("closing app...");
        Application.Quit();
    }
}

