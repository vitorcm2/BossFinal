using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


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
    GameManager gm;


    void Start()
    {
        gm = GameManager.GetInstance();
        movePoint.parent = null;
        characterScaleoriginal = transform.localScale;

    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        transform.localScale = characterScaleoriginal;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
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
                    }
                    else
                    {
                        transform.localScale = characterScaleoriginal;
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
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

    }



}

