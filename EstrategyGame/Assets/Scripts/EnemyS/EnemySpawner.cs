using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Enemy;
    [SerializeField]
    private Pool m_Pool;
    private static Pool piscina;
    [SerializeField]
    private EnemyInfo[] m_EnemyInfo;
    public static EnemyInfo[] m_EnemyInfos;
    public static Pool pool {

        get { return piscina; }
    
    }
    public void Start()
    {
        piscina = m_Pool;
        m_EnemyInfos = m_EnemyInfo;
    }

    public void ReturnElement(EnemigoController element)
    {
        m_Pool.ReturnElement(element.gameObject);
    }

    public void SpawnEnemy(EnemyInfo enemyInfo)
    {
        Vector3 TileDeAbajo = GameManager.WordToTile(new Vector3Int(15, 1));
        GameObject enemy = m_Pool.GetElement();
        if (enemy)
        {
            enemy.GetComponent<EnemigoController>().LoadInfo(enemyInfo, TileDeAbajo);
        }
    }
}
