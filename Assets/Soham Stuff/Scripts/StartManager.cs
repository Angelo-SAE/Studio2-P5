using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    [SerializeField] AudioSource buttonPress;


    private void Start()
    {
        buttonPress.mute = true;
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Tutorial");
    }
    
    public void PlayTutorial()
    {
        StartCoroutine(Tutorial());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainGame");
    }

    public void PlayStartGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public void PlayQuit()
    {
        StartCoroutine (Quit());
    }

    public void ButtonAudio()
    {
        buttonPress.mute = false;
        buttonPress.Play();
    }
}
