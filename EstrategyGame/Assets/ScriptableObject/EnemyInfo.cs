using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptables/Enemy Info")]
    public class EnemyInfo : ScriptableObject
    {
        public Sprite img;
        public int Casillas;
        public int ataque;
        public int Vida;
    }



