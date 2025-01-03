using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);   
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        juegoPausado = false;
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        juegoPausado = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        juegoPausado = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
