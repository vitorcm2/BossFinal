using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{

    public Text textTimer;
    GameManager gm;
    private float startTime;
    private bool canStart = true;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        gm = GameManager.GetInstance();




    }
    void Update()
    {

        if (gm.gameState == GameManager.GameState.GAME && canStart)
        {
            startTime = Time.time;
            canStart = false;
        }
        if (!canStart)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "WinOver")
            {
                Destroy(transform.gameObject);
            }

            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            if (!gm.gamePaused)
            {
                gm.timeElapsed += Time.deltaTime;
            }


            Debug.Log(gm.timeElapsed);

            textTimer.text = $"Time: {minutes}:{seconds}";

        }


    }
}
