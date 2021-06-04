using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{

    public Text textTimer;
    GameManager gm;
    private float startTime;
    void Start()
    {
        gm = GameManager.GetInstance();
        // DontDestroyOnLoad(transform.gameObject);
        if (gm.gameState == GameManager.GameState.GAME){
            startTime = Time.time;
        }

    }
    void Update()
    {
        // Debug.Log(textTimer.text);
        // int minutes = Mathf.FloorToInt(gm.time / 60F);
        // int seconds = Mathf.FloorToInt(gm.time - (minutes * 60));
        // string clockTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        // textTimer.text = $"Time: {clockTime}";

        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        textTimer.text = $"Time: {minutes}:{seconds}";

    }
}
