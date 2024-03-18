using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabletTutorialText : MonoBehaviour
{

    private string tutorialText;
    private TMP_Text tutorialTMPText;
    private bool completed;


    void Start()
    {
      tutorialTMPText = GetComponent<TMP_Text>();
    }

    void Update()
    {
      CheckForTabletStartTutorial();
      CheckForTabletOpen();
    }

    private void CheckForTabletStartTutorial()
    {
      if(Tablet.hasTablet && !completed)
      {
        completed = true;
        StartTutorial();
      }
    }

    private void StartTutorial()
    {
      tutorialTMPText.text = "Press R to use tablet";
    }

    private void CheckForTabletOpen()
    {
      if(completed && Input.GetKeyDown(KeyCode.R))
      {
        gameObject.SetActive(false);
      }
    }
}
