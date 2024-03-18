using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool canDrag;

    [SerializeField] private Room room;
    [SerializeField] private GameObject playerIndicator;
    private bool showingPlayer;

    void Update()
    {
      CheckIfCanDrag();
      ShowPlayerInRoom();
    }

    private void CheckIfCanDrag()
    {
      if(room.hasPlayer)
      {
        canDrag = false;
      } else {
        canDrag = true;
      }
    }

    private void ShowPlayerInRoom()
    {
      if(room.hasPlayer && !showingPlayer)
      {
        showingPlayer = true;
        playerIndicator.SetActive(true);
      } else if(!room.hasPlayer && showingPlayer)
      {
        showingPlayer = false;
        playerIndicator.SetActive(false);
      }
    }
}
