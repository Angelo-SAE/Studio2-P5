using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public string keyColor;
    public int keyNumber;
    public bool needsKey;
    public bool canOpen;
    [SerializeField] private bool isLastDoor;
    private bool closedDoor;
    [SerializeField] private Animator animator;

    void Update()
    {
      if(Mode.mode3D && !closedDoor)
      {
        closedDoor = true;
        CloseDoor();
      } else if(!Mode.mode3D && closedDoor)
      {
        closedDoor = false;
      }
    }

    public void OpenDoor()
    {
      if(canOpen || isLastDoor)
      {
        animator.SetBool("OpenDoor", true);
        Tablet.hasTablet = false;
        GameManager.canPause = false;
      }
    }

    private void CloseDoor()
    {
      animator.SetBool("OpenDoor", false);
    }
}
