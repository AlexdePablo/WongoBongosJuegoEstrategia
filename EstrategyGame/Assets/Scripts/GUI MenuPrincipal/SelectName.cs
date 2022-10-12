
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SelectName : MonoBehaviour
{
    public TMP_InputField inputText;
    public TMP_Text textoNombre;
    public Image luz;
    public GameObject botonAceptar;




    private void Awake()
    {
        luz.color = Color.red;
    }

    private void Update()
    {
        if (textoNombre.text.Length < 4)
        {
            luz.color = Color.red;
            botonAceptar.SetActive(false);
        }
        else if(textoNombre.text.Length >= 4)
        {
            luz.color = Color.green;
            botonAceptar.SetActive(true);
        }
    }
    public void aceptar()
    {
        PlayerPrefs.SetString("nombre1", inputText.text);
        SceneManager.LoadScene("");
    }
}
