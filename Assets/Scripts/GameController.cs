using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool gameOver;

    public static bool win;

    public static bool start = false;

    public GameObject LoseUI;
    public GameObject WinUI;

    public GameObject StartUI;

    public static int stage;

    private void Awake()
    {
        win = false;
        gameOver = false;
        start = false;
        Time.timeScale = 0f;
        stage = 0;
    }

    private void Update()
    {
        if (start)
        {
            if (!gameOver)
            {

            }
            else
            {
                LoseUI.SetActive(true);
                start = false;
                //Time.timeScale = 0f;
                Invoke("StopGame", 4f);
            }
            if (win)
            {
                WinUI.SetActive(true);
                Invoke("StopGame", 4f);
            }
        }
    }

    public void StartGame()
    {
        StartUI.SetActive(false);
        start = true;
        Time.timeScale = 1f;
        //GetComponent<PlayerController>().anim.SetBool("start", true);
        //GetComponent<EnemyController>().anim.SetBool("start", true);
        PlayerController.anim.SetBool("start", true);
        EnemyController.anim.SetBool("start", true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    void StopGame()
    {
        Time.timeScale = 0f;
    }
}
