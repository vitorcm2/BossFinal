using UnityEngine;
using UnityEngine.UI;

public class StarSystem : MonoBehaviour
{
    public Sprite[] StarSprites;
    public Image starUI;
    GameManager gm;


    // Update is called once per frame

    void Start()
    {
        gm = GameManager.GetInstance();

    }

    void Update()
    {
        starUI.sprite = StarSprites[gm.star];
    }

}
