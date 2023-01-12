using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPause;
    public bool isGameOver;
    public bool isWin = false;

    public GameObject panelPause;
    public GameObject panelGameOver;

    private void Awake()
    {
        if (instance != this && instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        AudioManager.instance.PlayBGM("Battle");
    }

    public bool GameOverOrPause()
    {
        panelPause.SetActive(isPause);
        
        if (isPause)
        {
            return true;
        } 
        
        else if (isGameOver)
        {
            panelGameOver.SetActive(true);
            return true;
        }
        
        else return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) isPause = !isPause;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
