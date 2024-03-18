using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private AudioSource staticAudio;
    private bool audioLoud;
    private AudioSource gunShotAudio;

    void Start()
    {
      gunShotAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
      if(!Mode.mode3D && audioLoud)
      {
        StaticReduceAnd2D();
      } else if(Mode.mode3D && !audioLoud)
      {
        Invoke("ResetStatic", 0.1f);
      }
    }

    private void StaticReduceAnd2D()
    {
      audioLoud = false;
      staticAudio.volume = 0.05f;
      staticAudio.spatialBlend = 0;
    }

    private void ResetStatic()
    {
      staticAudio.spatialBlend = 1;
      audioLoud = true;
      staticAudio.volume = 1;
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
