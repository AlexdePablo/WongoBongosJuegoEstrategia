
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CentimsFinal : MonoBehaviour
{
    [SerializeField]
    private Economy m_Centims;


    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = "Cèntims: "+m_Centims.ValorActual ;
    }


}
