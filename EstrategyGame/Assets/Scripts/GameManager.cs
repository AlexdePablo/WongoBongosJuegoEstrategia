using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Pathfinding))]
public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }
    [SerializeField]
    private Tilemap m_Tilemap;
    [SerializeField]
    private GameEventSpawnEnemigos spawn;
    [SerializeField]
    private Color m_PathColor;
    private static Tilemap Tilemap;
    private Pathfinding m_Pathfinding;
    public static bool comprar;
    public static Player m_py;
    private static bool m_Edit;
    private bool m_atacar;
    private EnemigoController m_ec;
    private bool m_TurnPlayer;
    public static bool Edit
    {
        get { return m_Edit; }
    }
    private void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        m_Edit = false;
        m_Pathfinding = GetComponent<Pathfinding>();
        Tilemap = m_Tilemap;
        m_atacar = false;
        m_TurnPlayer = true;
        comprar = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && m_Edit)
        {
            Vector3Int posicioCharacter = Vector3Int.FloorToInt(m_py.GetComponent<Transform>().position);
            Vector3Int cliked = m_Tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (m_Pathfinding.IsWalkableTile(cliked) && m_Pathfinding.IsWalkableTile(posicioCharacter) && !Player.m_TileOcuped)
            {
                List<Vector3Int> cells = new List<Vector3Int>();
                m_Pathfinding.FindPath(cliked, posicioCharacter, out cells);
                if (m_py.Distance >= cells.Count)
                {
                    ChangeTileColorSA(Vector3Int.FloorToInt(m_py.GetComponent<Transform>().position), m_py.Distance);
                    m_Edit = false;
                    List<Vector3> cellsWord = new List<Vector3>();
                    m_Pathfinding.FromCellPathToWorldPath(cells, out cellsWord);
                    cellsWord.Reverse();
                    if (m_atacar)
                    {
                        cellsWord.RemoveAt(cellsWord.Count-1);
                        StartCoroutine(m_py.PlayerMoveEvent(cellsWord));
                    }
                    else
                    {
                        StartCoroutine(m_py.PlayerMoveEvent(cellsWord));
                    }
                }
            }
        }
        Player.m_TileOcuped = false;
        if (EnemigoController.Active == 0 && !m_TurnPlayer)
        {
            Player[] Players = FindObjectsOfType<Player>();
            m_TurnPlayer = true;
            if (EnemySpawner.m_EnemyInfos != null)
                spawn.Raise(EnemySpawner.m_EnemyInfos[Random.Range(0, EnemySpawner.m_EnemyInfos.Length)]);
            foreach (Player p in Players)
            {
                p.yamove = false;
            }
        }
    }
    public void ChangeEditor(Player py)
    {
        if (m_TurnPlayer)
        {
            m_Edit = !m_Edit;
            m_py = py;
            Vector3Int posicioCharacter = Vector3Int.FloorToInt(m_py.GetComponent<Transform>().position);
            recursivo(posicioCharacter, m_py.Distance);
        }
    }
    public void recursivo(Vector3Int pos, int move)
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if ((j == 0 && i != 0) || (i == 0 && j !=0))
                {
                    Vector3Int vec = new Vector3Int(pos.x+i, pos.y+j, 0);
                    if (m_Pathfinding.IsWalkableTile(vec) && move > 1)
                    {
                        print(move);
                        recursivo(vec, move - 1);
                        ChangeTileColor(m_PathColor, vec);
                    }
                }
            }
        }
    }
    public static Vector3 WordToTile(Vector3Int position)
    {
       return Tilemap.GetCellCenterWorld(position);
    }
    public void EnemyClick()
    {
        m_atacar = true;
    }
    public void PathFindingEnemigo()
    {
        if (EnemySpawner.pool != null)
            foreach (GameObject Object in EnemySpawner.pool.m_Pool)
            {
                m_ec = Object.GetComponent<EnemigoController>();
                if (m_ec.isActiveAndEnabled)
                {
                    EnemigoController.Active++;
                    Vector3Int posicioEnemy = Vector3Int.FloorToInt(m_ec.GetComponent<Transform>().position);
                    Player p = PlayerMasCercano(posicioEnemy);
                    if (p != null)
                    {
                        Vector3Int posicioPlayer = Vector3Int.FloorToInt(p.transform.position);
                        if (m_Pathfinding.IsWalkableTile(posicioPlayer) && m_Pathfinding.IsWalkableTile(posicioEnemy))
                        {
                            List<Vector3Int> cells = new List<Vector3Int>();
                            m_Pathfinding.FindPath(posicioEnemy, posicioPlayer, out cells);
                            if (m_ec.CasillasQueSeMueve >= cells.Count)
                            {
                                List<Vector3> cellsWord = new List<Vector3>();
                                m_Pathfinding.FromCellPathToWorldPath(cells, out cellsWord);
                                cellsWord.RemoveAt(cellsWord.Count - 1);
                                StartCoroutine(m_ec.EnemyMovement(cellsWord));
                                p.QuitarVida(m_ec);
                            }
                            else
                            {
                                List<Vector3Int> cellsSublist = cells.GetRange(0, m_ec.CasillasQueSeMueve);
                                m_Edit = false;
                                List<Vector3> cellsWord = new List<Vector3>();
                                m_Pathfinding.FromCellPathToWorldPath(cellsSublist, out cellsWord);
                                StartCoroutine(m_ec.EnemyMovement(cellsWord));
                            }
                        }
                    }
                }
            }
        m_ec = null;
    }
    public void cambiarTurno()
    {
        if (m_TurnPlayer)
        {
            m_TurnPlayer = false;
            PathFindingEnemigo();
            comprar = false;
        }
    }
    public Player PlayerMasCercano(Vector3 pos)
    {
        Player[] PlayerMasCercano = FindObjectsOfType<Player>();
        Player masCrecano = null;
        int recorrido = 1000000000;
        foreach (Player p in PlayerMasCercano)
        {
            Vector3Int EnemyPosition = Vector3Int.FloorToInt(pos);
            Vector3Int playerPosition = Vector3Int.FloorToInt(p.GetComponent<Transform>().position);
            List<Vector3Int> cells = new List<Vector3Int>();
            m_Pathfinding.FindPath(EnemyPosition, playerPosition, out cells);
            if (cells.Count < recorrido)
            {
                masCrecano = p;
                recorrido = cells.Count;
            }
        }
        return masCrecano;
    }
    private void ChangeTileColorSA(Vector3Int pos, int move)
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (j == 0 && i != 0 || i == 0 && j != 0)
                {
                    Vector3Int vec = new Vector3Int(pos.x + i, pos.y + j, 0);
                    if (m_Pathfinding.IsWalkableTile(vec) && move > 1)
                    {
                        ChangeTileColorSA(vec, move - 1);
                        ChangeTileColor(Color.white, vec);
                    }
                }
            }
        }
    }
    private void ChangeTileColor(Color color, Vector3Int vector)
    {
        m_Tilemap.SetTileFlags(vector, TileFlags.None);
        m_Tilemap.SetColor(vector, color);
    }
}
