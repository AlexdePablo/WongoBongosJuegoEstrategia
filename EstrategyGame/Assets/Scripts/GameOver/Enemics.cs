using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemics : MonoBehaviour
{

    [SerializeField]
    private Economy m_Enemics;
    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = "Enemics derrotats: " + m_Enemics.ValorActual;
    }
}
