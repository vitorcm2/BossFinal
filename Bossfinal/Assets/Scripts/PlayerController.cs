using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform movePoint;
    public LayerMask whatStopMovement;

    public Animator animator;

    Vector3 characterScaleoriginal;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;
    public FontStyle Fonte;
    public GameObject ListaTargets;
    private Rigidbody2D rb;
    GameManager gm;



    void Start()
    {
        gm = GameManager.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        characterScaleoriginal = transform.localScale;
        transform.position = GameManager.lastPosition;
        movePoint.position = GameManager.lastPosition;

    }

    void Update()
    {
        //Debug.Log(GameManager.lastPosition);
        if (gm.gameState != GameManager.GameState.GAME) return;
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        transform.localScale = characterScaleoriginal;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        GameManager.lastPosition = transform.position;
        Vector3 characterScale = transform.localScale;

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            // press al the way to the right
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                animator.SetBool("IsHorizontal", true);
                animator.SetBool("Isvertical", false);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopMovement))
                {
                    if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        characterScale.x = -1 * characterScale.x;
                        transform.localScale = characterScale;
                        ListaTargets.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                    }
                    else
                    {
                        transform.localScale = characterScaleoriginal;
                        ListaTargets.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                    }
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                animator.SetBool("IsHorizontal", false);
                animator.SetBool("Isvertical", true);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    if (Input.GetAxisRaw("Vertical") < 0)
                    {
                        ListaTargets.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
                    }
                    else
                    {
                        ListaTargets.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                    }
                }
            }

        }

        if (gm.vidas == 0)
        {
            Debug.Log("DIEDDD");
            transform.position = new Vector3(-5.5f, -2.25f, 0);
            gm.ChangeState(GameManager.GameState.ENDGAME);
            SceneManager.LoadScene("GameOver");
        }

        if (gm.star == 5)
        {
            transform.position = new Vector3(-5.5f, -2.25f, 0);
            gm.ChangeState(GameManager.GameState.ENDGAME);
            SceneManager.LoadScene("WinOver");
        }


        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.gamePaused = true;
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

    }



}

