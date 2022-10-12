using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Name", menuName = "Scriptables/Name")]
public class Name : ScriptableObject
{

    public ArrayList names=new ArrayList();
    public Dictionary<string, int> enemigos = new Dictionary<string, int>() { };
    public Dictionary<string, int>  niveles = new Dictionary<string, int>() { };
    public string m_name;
}
