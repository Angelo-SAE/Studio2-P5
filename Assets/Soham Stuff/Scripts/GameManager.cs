using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pasueScreen;
    [SerializeField] int pauseIndex;

    private void Start()
    {
        Time.timeScale = 1.0f;
        pasueScreen.SetActive(false);
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseIndex % 2 is 0)
        {
            pauseIndex += 1;
            Time.timeScale = 0f;
            pasueScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pauseIndex % 2 is not 0)
        {
            pauseIndex += 1;
            Time.timeScale = 1;
            pasueScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pasueScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
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
