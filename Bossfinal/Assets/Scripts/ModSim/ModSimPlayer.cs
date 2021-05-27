
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//https://github.com/thiagoverardo/Waterwatch/blob/main/Waterwatch/Assets/Scripts/UI/GameOver.cs
public class ModSimPlayer : MonoBehaviour
{
    public GameObject[] heart;
    private bool dead;

    public Rigidbody2D rb;
    public bool isDead = false;
    GameManager gm;



    // Update is called once per frame

    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void Update()
    {

        if (isDead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Car")
        {

            Debug.Log("WE LOST!");
            isDead = true;
            gm.vidas--;

            SceneManager.LoadScene("SampleScene");

        }

        if (col.tag == "finish")
        {

            SceneManager.LoadScene("SampleScene");
        }
    }

}