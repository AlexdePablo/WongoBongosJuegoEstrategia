
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NamePlayerGUI : MonoBehaviour
{

    [SerializeField]
    private Name m_nameJugador;


    private void Awake()
    {

        GetComponent<TextMeshProUGUI>().text = m_nameJugador.m_name;
    }

}
