
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Centims : MonoBehaviour
{
    [SerializeField]
    private Economy m_Centims;

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = m_Centims.ValorActual.ToString();
    }
    public void Reload()
    {
        GetComponent<TextMeshProUGUI>().text = m_Centims.ValorActual.ToString();
    }
}
