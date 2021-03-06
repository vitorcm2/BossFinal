using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDesoft : MonoBehaviour
{
    Text text;
    public static float timeLeft = 15f;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        text = GetComponent<Text>();
        timeLeft = 15f;
        if (gm.star > 2)
        {
            timeLeft = 10f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            gm.TimerDesoft = true;
        }

        text.text = "Time Left: " + Mathf.Round(timeLeft);

    }
}
