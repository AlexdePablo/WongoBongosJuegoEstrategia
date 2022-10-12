using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CentimBasic : MonoBehaviour
{
    [SerializeField]
    private SoldierInfo m_Diners;


    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = ""+m_Diners.ValorDeMercado;
    }
}
