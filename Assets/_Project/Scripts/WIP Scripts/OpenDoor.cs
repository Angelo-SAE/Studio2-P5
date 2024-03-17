using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public static List<int> keyList = new List<int>();
    [SerializeField] private GameObject textPopup;
    private DoorOpen currentDoor;

    void Update()
    {
        CheckForMouseClick();
    }

    private void CheckForMouseClick()
    {
      if(Input.GetButtonDown("Fire1"))
      {
        CheckForDoor();
      }
    }

    private void CheckForDoor()
    {
      if(Interactable.interactableObject is not null)
      {
        if(Interactable.interactableObject.tag == "Door")
        {
          CheckIfDoorNeedsKey();
        }
      }
    }

    private void CheckIfDoorNeedsKey()
    {
      currentDoor = Interactable.interactableObject.GetComponent<DoorOpen>();
      if(currentDoor.needsKey == true)
      {
        CheckForAndUseKey();
      } else {
        OpenCurrentDoor();
      }
    }

    private void CheckForAndUseKey()
    {
      if(keyList.Contains(currentDoor.keyNumber))
      {
        currentDoor.needsKey = false;
        TutorialText.textText = currentDoor.keyColor + " key used";
        textPopup.SetActive(true);
        OpenCurrentDoor();
      } else {
        TutorialText.textText = "Missing: " + currentDoor.keyColor + " key";
        textPopup.SetActive(true);
      }
    }

    private void OpenCurrentDoor()
    {
      currentDoor.OpenDoor();
    }
}
