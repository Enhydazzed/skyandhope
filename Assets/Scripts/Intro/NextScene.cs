using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private Dialogue dialogueScript;

    private void Start()
    {
        // Mencari referensi ke skrip Dialogue
        dialogueScript = FindObjectOfType<Dialogue>();

        if (dialogueScript == null)
        {
            Debug.LogError("Dialogue script not found. Make sure there is a Dialogue component in the scene.");
        }
        else
        {
            Debug.Log("Dialogue script found successfully.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (dialogueScript != null)
            {
                if (dialogueScript.IsDialogueCompleted())
                {
                    Debug.Log("Dialogue completed. Loading next scene.");
                    SceneManager.LoadScene("Tutorial");
                }
                else
                {
                    Debug.Log("Dialogue not completed yet.");
                }
            }
            else
            {
                Debug.LogError("Dialogue script reference is null.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
