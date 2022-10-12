using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public int Ataque;
    private int Casillas;
    private int m_velocityMovement = 2;
    public static int Active;
    private string Tipo;
    [SerializeField]
    GameEvent Memuero;
    [SerializeField]
    GameEvent<EnemigoController> Memuerto;
    [SerializeField]
    private Economy m_Centims;
    [SerializeField]
    private Economy m_Enemics;
    public int CasillasQueSeMueve {

        get { return Casillas;  }
    
    }
    private float Vida;
    enum TipoDeEnemigo {PERRO, CABALLERO, BASICO };

    TipoDeEnemigo t;
    public void LoadInfo(EnemyInfo infoEnemy, Vector3 initialPosition)
    {
        this.transform.position = initialPosition;
        this.Ataque = infoEnemy.ataque;
        this.Casillas = infoEnemy.Casillas;
        this.Vida = infoEnemy.Vida;
        Tipo = infoEnemy.name;
        //GetComponent<SpriteRenderer>().sprite = infoEnemy.img;
    }


   public IEnumerator EnemyMovement(List<Vector3> m_Cells) {
        Vector3Int m_Origin = Vector3Int.FloorToInt(GetComponent<Transform>().position);
        foreach (Vector3 cell in m_Cells)
        {
            Vector3 PlayerPosition = GetComponent<Transform>().position;
            Vector2 VelocityToCell = new Vector2((cell.x - PlayerPosition.x) * m_velocityMovement, (cell.y - PlayerPosition.y) * m_velocityMovement);
            GetComponent<Rigidbody2D>().velocity = VelocityToCell;
            yield return new WaitUntil(() => GetComponent<Transform>().position == cell);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        Active--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Poolable>().ReturnToPool();
    }
    private void OnMouseDown()
    {
        if (GameManager.Edit)
        {
            Memuero.Raise();
            Vida = Vida - GameManager.m_py.m_ataque;
            if (Vida <= 0)
            {
                if (Tipo.Equals("Basico"))
                    m_Centims.ValorActual += 2;
                else if (Tipo.Equals("Perro"))
                    m_Centims.ValorActual += 4;
                else if (Tipo.Equals("Caballero"))
                    m_Centims.ValorActual += 7;
                else if (Tipo.Equals("Comandante"))
                    m_Centims.ValorActual += 12;
                m_Enemics.ValorActual++;
                Memuerto.Raise(this);
            }
        }
    }
}
