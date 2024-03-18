using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private AudioSource staticAudio;
    private AudioSource gunShotAudio;

    void Start()
    {
      gunShotAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter()
    {
      gunShotAudio.Play(0);
      staticAudio.Stop();
      blackScreen.SetActive(true);
      Invoke("GoToMainMenu", 3f);
    }

    private void GoToMainMenu()
    {
      gameManager.MainMenu();
    }
}
