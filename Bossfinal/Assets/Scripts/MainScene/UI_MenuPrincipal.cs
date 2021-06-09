using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPrincipal : MonoBehaviour
{

    GameManager gm;
    void Start()
    {
        gm.gamePaused = true;
    }
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Comecar()
    {
        gm.gamePaused = false;
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Instructions()

    {
        gm.ChangeState(GameManager.GameState.INSTRUCTIONS);
    }

    public void Voltar()
    {

        gm.ChangeState(GameManager.GameState.MENU);
    }
    public void VoltarGAME()
    {
        gm.gamePaused = false;
        gm.ChangeState(GameManager.GameState.GAME);
    }
}