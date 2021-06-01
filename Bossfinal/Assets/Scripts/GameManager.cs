using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
    private static GameManager _instance;

    public enum GameState { MENU, GAME, PAUSE, ENDGAME, INSTRUCTIONS, WINGAME };

    public GameState gameState { get; set; }

    public bool lostGDE,lostINSTRU;
    public int vidas;

    public int star;



    public bool winDani, winCarlinhos;
    public bool winPaulina;

    public bool TimesUPDani,TimerInstru;



    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        lostGDE = true;
        vidas = 3;
        star = 0;

        winPaulina = false;
        winDani = false;
        TimesUPDani = false;
        TimerInstru = false;
        gameState = GameState.MENU;
    }


    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        lostGDE = true;
        winPaulina = false;
        winDani = false;
        vidas = 3;
        star = 0;

    }
}