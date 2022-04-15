using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PauseMenu is Running");
        Debug.Log(isPaused);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Debug.Log("Resuming");
                Resume();
            }
            else
            {
                Debug.Log("Pausing");
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Are we hitting this?");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
