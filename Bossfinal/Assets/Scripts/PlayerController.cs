using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform movePoint;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        // press al the way to the right
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
    }
}

