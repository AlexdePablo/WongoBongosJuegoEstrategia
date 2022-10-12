using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickedComander : MonoBehaviour
{
    [SerializeField]
    private GameEvent<int, Vector3> m_ClickEvent;
    [SerializeField]
    private SoldierInfo m_SoldierInfo;
    [SerializeField]
    private Economy m_Centims;
    public void ButtonSpawnSoldier()
    {
        Vector3 pos = GameManager.WordToTile(new Vector3Int(-18, 5));
        if (m_SoldierInfo.ValorDeMercado <= m_Centims.ValorActual && !GameManager.comprar)
        {
            m_ClickEvent.Raise(3, pos);
            m_Centims.ValorActual -= m_SoldierInfo.ValorDeMercado;
            GameManager.comprar = true;
        }
    }
}
