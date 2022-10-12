using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoldierInfo", menuName = "Scriptables/SoldierInfo")]
public class SoldierInfo : ScriptableObject
{
    public int vida;
    public int Ataque;
    public int DistanceTurn;
    public int ValorDeMercado;
    public Sprite img;
}
