using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{
    public GameObject canvas;
    private bool isPaused = false; 
    public void play()
    {
        SceneManager.LoadScene("Play");

    }
    public void exit()
    {
        Application.Quit();

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Play")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused; 

                if (isPaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        canvas.SetActive(true); 
        Time.timeScale = 0f; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true   ;
    }

    public void ResumeGame()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
