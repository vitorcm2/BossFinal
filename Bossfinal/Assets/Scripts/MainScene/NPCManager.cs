using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public NPCfollow dani;
    public NPCfollow paulina;

    public NPCfollow carlinhos;
    public NPCfollow daniel;
    public NPCfollow raul;
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
        if (gm.winCarlinhos)
        {
            carlinhos.enabled = true;
        }
        if (gm.winRaul)
        {
            raul.enabled = true;
        }
        if (gm.winDaniel)
        {
            daniel.enabled = true;
        }

    }
}
