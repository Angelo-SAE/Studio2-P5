using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public string keyColor;
    public int keyNumber;
    public bool needsKey;
    public bool canOpen;
    public bool closedDoor;
    [SerializeField] private GameObject openDoorAudio, closeDoorAudio;
    [SerializeField] private AudioSource rain;
    [SerializeField] private bool isLastDoor;
    [SerializeField] private Animator animator;
    private bool resetDoor;

    void Update()
    {
      if(Mode.mode3D && !closedDoor && resetDoor)
      {
        resetDoor = false;
        CloseDoor();
      } else if(!Mode.mode3D && !closedDoor && !resetDoor)
      {
        resetDoor = true;
      }
    }

    public void OpenDoor()
    {
      if(canOpen)
      {
        closedDoor = false;
        animator.SetBool("OpenDoor", true);
        Instantiate(openDoorAudio, transform.position, transform.rotation, transform);
      } else if(isLastDoor)
      {
        animator.SetBool("OpenDoor", true);
        Instantiate(openDoorAudio, transform.position, transform.rotation, transform);
        Tablet.hasTablet = false;
        GameManager.canPause = false;
        rain.Stop();
      }
    }

    public void CloseDoor()
    {
      closedDoor = true;
      animator.SetBool("OpenDoor", false);
      Instantiate(closeDoorAudio, transform.position, transform.rotation, transform);
    }
}
