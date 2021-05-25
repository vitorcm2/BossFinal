using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{
    public string dialogue;

    private DialogueManager dm;
    // Start is called before the first frame update
    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (col.gameObject.CompareTag("Player"))
        {

            // if (Input.GetKeyDown(KeyCode.Escape))
            // {
            dm.showBox(dialogue);
            // }
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        dm.stopShow();
    }
}
