
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GameOverAnimator : MonoBehaviour
{
    [SerializeField]
    Animation animacion;
    void Start()
    {
        animacion.Play("AnimacioGameOver");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
