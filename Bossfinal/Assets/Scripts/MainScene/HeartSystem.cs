using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public Sprite[] HeartSprites;
    public Image heartUI;
    GameManager gm;


    // Update is called once per frame

    void Start()
    {
        gm = GameManager.GetInstance();

    }

    void Update()
    {
        heartUI.sprite = HeartSprites[gm.vidas];
    }

}
