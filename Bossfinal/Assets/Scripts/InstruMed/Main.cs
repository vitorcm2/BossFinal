using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    GameManager gm;

    public int switchCount;
    private int onCount = 0;
    private void Awake()
    {
        Instance = this;
        gm = GameManager.GetInstance();
    }
    public void SwitchChange(int points)
    {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            Debug.Log("ACABOU");
            gm.lostINSTRU = false;
            gm.winCarlinhos = true;
            gm.star++;
            SceneManager.LoadScene("SampleScene");
        }

    }
    private void Update()
    {
        if (gm.TimerInstru)
        {
            gm.vidas--;
            gm.lostINSTRU = true;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
