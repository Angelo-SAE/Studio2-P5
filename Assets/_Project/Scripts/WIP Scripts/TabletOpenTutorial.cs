using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletOpenTutorial : MonoBehaviour
{
    [SerializeField] private GameObject tabletTutorial;
    private bool tutorialActive;

    // Update is called once per frame
    void Update()
    {
      if(!Mode.mode3D && tutorialActive)
      {
        tutorialActive = false;
        tabletTutorial.SetActive(true);
      } else if(Mode.mode3D && !tutorialActive)
      {
        tutorialActive = true;
        tabletTutorial.SetActive(false);
      }
    }
}
