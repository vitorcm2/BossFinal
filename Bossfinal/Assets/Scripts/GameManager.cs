using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{   private static GameManager _instance;

    public enum GameState { MENU, GAME, PAUSE, ENDGAME, INSTRUCTIONS };

    public GameState gameState { get; private set; }

    public bool lostGDE;
    public int vidas;
    


   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }
   private GameManager()
   {
       lostGDE = true;
       vidas = 3;
       gameState = GameState.MENU;
   }

   
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
    gameState = nextState;
    changeStateDelegate();
    }
}