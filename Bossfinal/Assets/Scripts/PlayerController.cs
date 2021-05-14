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



    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if( Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            // press al the way to the right
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                animator.SetBool("IsHorizontal", true);
                animator.SetBool("Isvertical", false);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),0.2f, whatStopMovement)){
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                animator.SetBool("IsHorizontal", false);
                animator.SetBool("Isvertical", true);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"),0f),0.2f, whatStopMovement)){
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }
}

