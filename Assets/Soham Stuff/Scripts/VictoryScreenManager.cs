using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenManager : MonoBehaviour
{
    [SerializeField] AudioSource buttonAudio;

    private void Start()
    {
        buttonAudio.mute = true;
    }

    IEnumerator Replay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainGame");
    }

    public void StartReplay()
    {
        StartCoroutine(Replay());
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    public void StartMainMenu()
    {
        StartCoroutine(MainMenu());
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    public void StartQuit()
    {
        StartCoroutine(Quit());
    }

    public void ButtonAudio()
    {
        buttonAudio.mute = false;
        buttonAudio.Play();
    }
}
