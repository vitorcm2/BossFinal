using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{
    public string dialogue;

    public int scene;

    private bool trigger = false;
    private DialogueManager dm;
    // Start is called before the first frame update
    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger && Input.GetKeyDown(KeyCode.Space))
        {
            dm.goToScene(scene);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.CompareTag("Player"))
        {
            trigger = true;
            dm.showBox(dialogue);

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        trigger = false;
        dm.stopShow();
    }
}
