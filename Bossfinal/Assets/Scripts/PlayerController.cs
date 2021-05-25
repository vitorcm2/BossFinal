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
    private bool playerEntered;
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

        setupGui();

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

        if (playerEntered)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                gm.ChangeState(GameManager.GameState.MENU);
            }
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Professor"))
            playerEntered = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Professor"))
            playerEntered = false;
    }

    #region GUI Config

    //configure the style of the GUI
    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = Fonte;
        guiStyle.normal.textColor = Color.white;
        msg = "Press E to Talk";
    }

    void OnGUI()
    {
        if (playerEntered)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
        }
    }
    //End of GUI Config --------------
    #endregion

}

