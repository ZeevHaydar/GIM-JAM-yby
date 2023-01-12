using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainView : MonoBehaviour
{
    private void Start() => AudioManager.instance.PlayBGM("Main Menu");

    public void ChangeScene(string name) => SceneManager.LoadScene(name);
    
    public void Quit() => Application.Quit();
}
