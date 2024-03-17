using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    public static bool hasTablet;

    void Update()
    {
        CheckForMouseClick();
    }

    private void CheckForMouseClick()
    {
      if(Input.GetButtonDown("Fire1"))
      {
        CheckForTablet();
      }
    }

    private void CheckForTablet()
    {
      if(Interactable.interactableObject is not null)
      {
        if(Interactable.interactableObject.tag == "Tablet")
        {
          hasTablet = true;
          gameObject.SetActive(false);
        }
      }
    }
}
