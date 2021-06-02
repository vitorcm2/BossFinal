using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Typer : MonoBehaviour
{
    // frases
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = "print('hello word')";
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        SettCurrentWord();
    }

    void SettCurrentWord()
    {
        SetRemainingWord(currentWord);
    }

    void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        if (gm.TimerDesoft)
        {
            gm.vidas--;
            gm.lostDESOFT = true;
            SceneManager.LoadScene("SampleScene");
        }
    }

    void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    void EnterLetter(string typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordCompleted())
            {
                gm.lostDESOFT = false;
                gm.winRaul = true;
                gm.star++;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    void RemoveLetter()
    {
        string newString = remainingWord.Remove(0,1);
        SetRemainingWord(newString);
    }

    bool IsWordCompleted()
    {
        return remainingWord.Length == 0;
    }
}
