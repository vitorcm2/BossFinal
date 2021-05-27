﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public NPCfollow dani;
    public NPCfollow paulina;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.winDani)
        {
            dani.enabled = true;
        }
        if (gm.winPaulina)
        {
            paulina.enabled = true;
        }
    }
}
