using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Agulha : MonoBehaviour
{

    GameManager gm;

    public Spinner _spinner;
    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (!_spinner.isStoped)
            return;
        if (col.gameObject.CompareTag("GDE"))
        {
            gm.lostGDE = false;
            gm.winDani = true;
            gm.star++;
            SceneManager.LoadScene("SampleScene");

        }
        else
        {
            gm.lostGDE = true;
            gm.vidas -= 1;
            SceneManager.LoadScene("SampleScene");

        }


    }

}