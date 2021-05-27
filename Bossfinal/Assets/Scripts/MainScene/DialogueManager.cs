using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public AudioSource notification;
    public bool dialogActive;

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogActive = false;

        }

    }

    public void goToScene(int scene)
    {
        SceneManager.LoadScene(scene);

    }
    public void showBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        notification.Play();
        dText.text = dialogue;
    }

    public void stopShow()
    {
        dialogActive = false;
        dBox.SetActive(false);

    }
}
