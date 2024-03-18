using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] int pauseIndex;
    [SerializeField] RestartGame resetGameScript;


    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseIndex % 2 is 0 && Mode.mode3D)
        {
            isPaused = true;
            pauseIndex += 1;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pauseIndex % 2 is not 0)
        {
            isPaused = false;
            pauseIndex += 1;
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        isPaused = false;
        pauseIndex += 1;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        resetGameScript.RestartGameFunction();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        PauseGame();
    }
}
