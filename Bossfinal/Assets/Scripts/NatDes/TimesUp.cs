using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimesUp : MonoBehaviour
{
    Text text;
    public static float timeLeft = 10f;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 10f;
        gm = GameManager.GetInstance();
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            gm.TimesUPDani = true;
        }

        text.text = "Time Left: " + Mathf.Round(timeLeft);

    }
}
