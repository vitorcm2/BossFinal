
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ModSimPlayer : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool isDead = false;

    // Update is called once per frame


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
            SceneManager.LoadScene("SampleScene");
        }

        if (col.tag == "finish")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}