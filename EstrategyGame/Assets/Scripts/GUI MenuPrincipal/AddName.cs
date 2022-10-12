
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class AddName : MonoBehaviour
{
    [SerializeField]
    public TMP_Text text;

    [SerializeField]
    private Name m_Nombre;

    [SerializeField]
    private GameObject uSure;
    [SerializeField]
    private GameObject MenuPrincipal;
    [SerializeField]
    private GameObject MenuNombre;

    public string getName()
    {
        return m_Nombre.m_name;
    }

    public void setName([SerializeField] TMP_Text text)
    {
        uSure.SetActive(false);
        MenuPrincipal.SetActive(true);
        MenuNombre.SetActive(false);
        m_Nombre.m_name = text.text.ToString();
    }

    public void checkName()
    {
        Debug.Log("A chequear");
        print(text.text.ToString());


        if (m_Nombre.names.Count > 0)
        {
            foreach (string Names in m_Nombre.names)
            {
                if (text.text.ToString() == Names)
                {
                    print("mamame el bicho kbron");
                    uSure.SetActive(true);
                }
                else
                {
                    MenuPrincipal.SetActive(true);
                    MenuNombre.SetActive(false);
                    m_Nombre.m_name = text.text;
                    m_Nombre.names.Add(text.text);
                    m_Nombre.enemigos.Add(text.text, 0);
                    m_Nombre.niveles.Add(text.text, 1);
                    Debug.Log(m_Nombre.m_name.ToString());
                }

            }
        }
        else
        {
            MenuPrincipal.SetActive(true);
            MenuNombre.SetActive(false);
            m_Nombre.m_name = text.text;
            m_Nombre.names.Add(text.text);
            m_Nombre.enemigos.Add(text.text, 0);
            m_Nombre.niveles.Add(text.text, 1);
        }
        print(m_Nombre.m_name);
        print(m_Nombre.names.Count);

        /*  m_Nombre.enemigos.Add("Aurora", 48);
          m_Nombre.niveles.Add("Aurora",4);

          m_Nombre.enemigos.Add("polar", 43);
          m_Nombre.niveles.Add("polar", 3);

          m_Nombre.enemigos.Add("nata", 50);
          m_Nombre.niveles.Add("nata", 3);

          m_Nombre.enemigos.Add("zoro", 1);
          m_Nombre.niveles.Add("zoro", 6);

          m_Nombre.enemigos.Add("choco", 456);
          m_Nombre.niveles.Add("choco", 8);

          m_Nombre.enemigos.Add("momo", 75);
          m_Nombre.niveles.Add("momo", 6);

          m_Nombre.enemigos.Add("taliban", 756);
          m_Nombre.niveles.Add("taliban", 5);
        */
    }
}
