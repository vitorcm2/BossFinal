using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=J2mja7s4SFg
// aula7 6m12s
public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    public static float timeLeft = 4f;

    IntroNatDes des;

    GameManager gm;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    void Start()
    {
        gm = GameManager.GetInstance();
        gm.TimesUPDani = false;
        timeLeft = 4f;


        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        StartCoroutine("ShowAllPuzzles");

        // ShowAllPuzzles();

        gameGuesses = gamePuzzles.Count / 2;
    }


    void Update()
    {
        Debug.Log(gm.TimesUPDani);
        if (gm.TimesUPDani)
        {
            if (countCorrectGuesses != gameGuesses)
            {
                gm.vidas--;
                Debug.Log("perdeu");
                SceneManager.LoadScene("SampleScene");
            }
        }


    }

    IEnumerator ShowAllPuzzles()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");


        for (int i = 0; i < objects.Length; i++)
        {
            btns[i].image.sprite = gamePuzzles[i];

        }
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }


    }
    // void ShowAllPuzzles()
    // {
    //     GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");


    //     for (int i = 0; i < objects.Length; i++)
    //     {
    //         btns[i].image.sprite = gamePuzzles[i];
    //     }

    // }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("cliked a button" + name);

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfPuzzlesMatch());
        }
    }

    IEnumerator CheckIfPuzzlesMatch()
    {
        yield return new WaitForSeconds(0.2f);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.2f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(0.2f);
        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            gm.star++;
            Debug.Log("game finished");
            SceneManager.LoadScene("SampleScene");

        }

    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIdx = Random.Range(i, list.Count);
            list[i] = list[randomIdx];
            list[randomIdx] = temp;
        }

    }
}
