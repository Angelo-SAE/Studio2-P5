using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] AudioSource buttonAudio;

    private void Start()
    {
        buttonAudio.mute = true;
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(0.3f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void StartContinue()
    {
        StartCoroutine(Continue());
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
    }

    public void StartMainMenu()
    {
        StartCoroutine (MainMenu());
    }

    public void ButtonAudio()
    {
        buttonAudio.mute = false;
        buttonAudio.Play();
    }
}
