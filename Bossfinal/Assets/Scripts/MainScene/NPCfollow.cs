using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool to_follow;
    public Transform target;

    public Animator animator;
    // GameManager gm;
    void Start()
    {
        to_follow = true;
        speed = 4.5f;
        transform.position = GameManager.lastPositionNPC;

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if (to_follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            GameManager.lastPositionNPC = transform.position;
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                animator.SetBool("isHorizontal", true);
                animator.SetBool("isVertical", false);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                animator.SetBool("isHorizontal", false);
                animator.SetBool("isVertical", true);
            }
        }



    }
}