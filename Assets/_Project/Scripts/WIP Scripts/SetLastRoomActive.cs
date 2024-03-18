using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLastRoomActive : MonoBehaviour
{
    [SerializeField] private GameObject lastRoom;
    private bool isEnabled;

    void Update()
    {
      if(!isEnabled)
      {
        CheckForLastRoomEnable();
      }
    }

    private void CheckForLastRoomEnable()
    {
      if(OpenDoor.keyList.Count == 4)
      {
        isEnabled = true;
        lastRoom.SetActive(true);
      }
    }
}
