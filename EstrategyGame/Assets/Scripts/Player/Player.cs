using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SoldierInfo m_Info;
    [SerializeField]
    private GameEvent m_VidaEvent;
    [SerializeField]
    private GameEvent<Player> m_muerto;
    public int m_ataque;
    private int vida;
    public bool yamove;
    private int m_velocityMovement;
    public int m_DistanceForTurn;
    public static bool m_TileOcuped;
    public int Distance
    {
           get { return m_DistanceForTurn; }
    }
    [SerializeField]
    private GameEvent<Player> m_ClickEvent;

    private void Start()
    {
        yamove = false;
        m_velocityMovement = 2;
        m_TileOcuped = false;
    }
    public void LoadInfo(SoldierInfo infoSoldier, Vector3 initialPosition)
    {
        transform.position = initialPosition;
        m_DistanceForTurn = infoSoldier.DistanceTurn;
        vida = infoSoldier.vida;
        m_ataque = infoSoldier.Ataque;
        //GetComponent<SpriteRenderer>().sprite = infoEnemy.img;
    }
    public IEnumerator PlayerMoveEvent(List<Vector3> m_Cells)
    {
        Vector3Int m_Origin = Vector3Int.FloorToInt(GetComponent<Transform>().position);
        foreach (Vector3 cell in m_Cells)
        {
            Vector3 PlayerPosition = GetComponent<Transform>().position;
            Vector2 VelocityToCell = new Vector2((cell.x - PlayerPosition.x) * m_velocityMovement, (cell.y - PlayerPosition.y) * m_velocityMovement);
            GetComponent<Rigidbody2D>().velocity = VelocityToCell;
            yield return new WaitUntil(() => GetComponent<Transform>().position == cell);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        yamove = true;
    }
    private void OnMouseUp()
    {
        if (!GameManager.Edit && !m_TileOcuped && !yamove)
            m_ClickEvent.Raise(this);
    }
    private void OnMouseDown()
    {
        if (GameManager.Edit)
            m_TileOcuped = true;
    }
    public void QuitarVida(EnemigoController ec)
    {
        vida = vida - ec.Ataque;
        if (vida <= 0)
        {
            m_muerto.Raise(this);
            Player[] PlayerMasCercano = FindObjectsOfType<Player>();
            if (PlayerMasCercano.Length == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
