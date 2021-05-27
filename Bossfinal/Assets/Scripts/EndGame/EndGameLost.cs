using UnityEngine.SceneManagement;
using UnityEngine;


public class EndGameLost : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
    // Update is called once per frame
    public void Endgame()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        gm.vidas = 3;
        SceneManager.LoadScene("SampleScene");
    }

}
