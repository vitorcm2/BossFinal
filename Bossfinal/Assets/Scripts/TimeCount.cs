using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{

    public Text textTimer;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
        DontDestroyOnLoad(transform.gameObject);
    }
    void Update()
    {
        // Debug.Log(textTimer.text);
        int minutes = Mathf.FloorToInt(gm.time / 60F);
        int seconds = Mathf.FloorToInt(gm.time - (minutes * 60));
        string clockTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        textTimer.text = $"Time: {clockTime}";
    }
}
