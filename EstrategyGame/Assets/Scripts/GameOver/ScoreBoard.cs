using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ScoreBoard : MonoBehaviour
{
    private string linea="";
    [SerializeField]
    private Name m_name;
    int count = 0;
  
    private void Awake()
    {
            foreach (KeyValuePair<string, int> niveles in m_name.niveles.OrderByDescending(user => user.Value))
            {
            if (count < 6)
            {
                linea = linea + niveles.Key + " Nivell: " + niveles.Value + " Enemics derrotats: " + m_name.enemigos[niveles.Key] + "\n";
                count++;
            }
        }
    }
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = linea;
    }
}
