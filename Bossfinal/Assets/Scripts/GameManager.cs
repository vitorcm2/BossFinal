using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
    private static GameManager _instance;

    public enum GameState { MENU, GAME, PAUSE, ENDGAME, INSTRUCTIONS, WINGAME };

    public GameState gameState { get; set; }

    public bool lostGDE, lostINSTRU, lostDESOFT;
    public int vidas;

    public int star;

    public float timeElapsed;
    private float initialTime = 0.0f;
    public PlayerController playerPosition;

    public bool gamePaused = false;

    public static Vector3 lastPosition;

    public bool winDani, winCarlinhos, winRaul, winDaniel, winPaulina;

    public bool TimesUPDani, TimerInstru, TimerDesoft;


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
        lostDESOFT = true;
        vidas = 3;
        star = 0;

        winPaulina = false;
        winDani = false;
        winRaul = false;
        winDaniel = false;
        winCarlinhos = false;

        TimesUPDani = false;
        TimerInstru = false;
        TimerDesoft = false;
        lastPosition = new Vector3(3, -1.58f, 0);
        gameState = GameState.MENU;

        timeElapsed = initialTime;
        gamePaused = false;

    }


    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.MENU) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        lostGDE = true;
        vidas = 3;
        star = 0;

        winPaulina = false;
        winDani = false;
        winRaul = false;
        winDaniel = false;
        winCarlinhos = false;

        timeElapsed = initialTime;
        gamePaused = false;
    }
}