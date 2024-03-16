using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public List<int> keyList = new List<int>();
    private DoorOpen currentDoor;

    void Start()
    {
      keyList.Add(1);
      keyList.Add(2);
      keyList.Add(3);
      keyList.Add(4);
      keyList.Add(5);
    }

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
        if(Interactable.interactableObject.tag== "Door")
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
        Debug.Log(currentDoor.keyColor + " key used");
        OpenCurrentDoor();
      } else {
        Debug.Log("Missing: " + currentDoor.keyColor + " key");
      }
    }

    private void OpenCurrentDoor()
    {
      currentDoor.OpenDoor();
    }
}
