using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform target;
    private bool to_follow;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        to_follow = true;
        speed = 4.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (to_follow){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
