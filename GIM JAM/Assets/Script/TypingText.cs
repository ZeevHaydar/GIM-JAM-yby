using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    public TMP_Text dialogText;
    public float delayNextMonolog;
    public float typingSpeed;
    public GameObject Buttons;
    [TextArea(5, 8)] public string[] dialogWin;
    [TextArea(5, 8)] public string[] dialogLose;
    [TextArea(5, 8)] public string dialogPause;

    private void Start()
    {
        if (GameManager.instance.isWin && GameManager.instance.isGameOver)
        {
            StartCoroutine(TypingMonologWin());
        }
        
        else if (!GameManager.instance.isWin && GameManager.instance.isGameOver)
        {
            StartCoroutine(TypingMonologLose());
        } 
        
        else if (GameManager.instance.isPause)
        {
            StartCoroutine(TypingMonologPause());
        }
    }

    IEnumerator TypingMonologLose()
    {
        for (int i = 0; i < dialogLose.Length; i++)
        {
            dialogText.text = String.Empty;

            for (int j = 0; j < dialogLose[i].Length; j++)
            {
                dialogText.text += (char)dialogLose[i][j];

                yield return new WaitForSeconds(typingSpeed);
            }
            
            yield return new WaitForSeconds(delayNextMonolog);
        }
        
        Buttons.SetActive(true);
    }
    
    IEnumerator TypingMonologWin()
    {
        for (int i = 0; i < dialogWin.Length; i++)
        {
            dialogText.text = String.Empty;

            for (int j = 0; j < dialogWin[i].Length; j++)
            {
                dialogText.text += (char)dialogWin[i][j];

                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(delayNextMonolog);
        }

        Buttons.SetActive(true);
    }

    IEnumerator TypingMonologPause()
    {
        dialogText.text = String.Empty;

        for (int i = 0; i < dialogPause.Length; i++)
        {
            dialogText.text += (char)dialogPause[i];

            yield return new WaitForSeconds(typingSpeed);
        }
        
        Buttons.SetActive(true);
    }
}
