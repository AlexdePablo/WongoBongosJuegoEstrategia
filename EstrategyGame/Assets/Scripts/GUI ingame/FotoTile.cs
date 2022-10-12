
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoTile : MonoBehaviour
{
    public Sprite newImage;
    public Sprite newImage2;
    public Sprite newImage3;
    public Sprite newImage4;
    private Image myIMGcomponent;
    public int numero;

    // Use this for initialization
    void Start()
    {
        myIMGcomponent = this.GetComponent<Image>();
        myIMGcomponent.sprite = newImage;
    }
    public void cambioTile()
    {
        if (numero == 1)
        {
            myIMGcomponent.sprite = newImage;
        }
        if (numero == 2)
        {
            myIMGcomponent.sprite = newImage2;
        }
        if (numero == 3)
        {
            myIMGcomponent.sprite = newImage3;
        }
        if (numero == 4)
        {
            myIMGcomponent.sprite = newImage4;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
