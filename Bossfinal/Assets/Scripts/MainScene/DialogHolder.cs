using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{
    public string dialogue;

    public int scene;
    public bool isShowing;

    public GameObject ProfessorAtual;

    private bool trigger = false;
    private DialogueManager dm;

    GameManager gm;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        isShowing = true;
        gm = GameManager.GetInstance();
        dm = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.winPaulina && ProfessorAtual.name == "Paulina" || gm.winDani && ProfessorAtual.name == "Dani" || gm.winRaul && ProfessorAtual.name == "Raul" || gm.winDaniel && ProfessorAtual.name == "Daniel" || gm.winCarlinhos && ProfessorAtual.name == "Carlinhos" )
        {
            isShowing = false;        
        }
        if (trigger && Input.GetKeyDown(KeyCode.Space))
        {
            dm.goToScene(scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.CompareTag("Player"))
        {
            if (isShowing){
                trigger = true;
                dm.showBox(dialogue);
            }

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        trigger = false;
        dm.stopShow();
    }
}
