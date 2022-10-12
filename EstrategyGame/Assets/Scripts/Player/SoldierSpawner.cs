using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField]
    private Pool m_Pool;
    [SerializeField]
    private GameObject m_Soldier;
    [SerializeField]
    private SoldierInfo[] m_SoldierInfo;

    public void ReturnElement(Player element)
    {
        m_Pool.ReturnElement(element.gameObject);
    }

    public void SpawnSoldier(int num, Vector3 spawnPosition)
    {
        GameObject Soldier = m_Pool.GetElement();
        print(num);
        if (Soldier)
        {
            Soldier.GetComponent<Player>().LoadInfo(m_SoldierInfo[num], spawnPosition);
        }
    }
}
