using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] heart;
    private bool dead;
    private int life = 0;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }

    }

    public void TakeDamage()
    {
        gm.vidas--;
        life++;
        Destroy(heart[life].gameObject);
        if (gm.vidas == 0)
        {
            dead = true;
        }
    }
}
