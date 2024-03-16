using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickDrag : MonoBehaviour
{

    private GameObject draggableObject;
    [SerializeField] private Camera camera2D;
    private Vector2 mousePosition, mouseClickPosition, origionalPosition;

    void Update()
    {
        mousePosition = camera2D.ScreenToWorldPoint(Input.mousePosition);
        if(!Mode.mode3D)
        {
          GetDraggableObject();

          if(draggableObject != null)
          {
            MoveDraggableObject();
          }
        }
    }

    private void GetDraggableObject()
    {
      if(Input.GetMouseButtonDown(0))
      {
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

        if(targetObject != null)
        {
          if(targetObject.tag == "Draggable")
          {
            draggableObject = targetObject.transform.gameObject;
            mouseClickPosition = mousePosition;
            Draggable dragScript = draggableObject.GetComponent<Draggable>();
            origionalPosition = new Vector2(draggableObject.transform.position.x, draggableObject.transform.position.y);
          }
        }
      }
      if(Input.GetMouseButtonUp(0))
      {
        if(draggableObject != null)
        {
          SetPositionOfObject();
          draggableObject = null;
        }
      }
    }

    private void MoveDraggableObject()
    {
      draggableObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, draggableObject.transform.position.z);
    }

    private void SetPositionOfObject()
    {
      Vector2 tempPosition = new Vector2(draggableObject.transform.position.x, draggableObject.transform.position.y);
      Vector2 closest = origionalPosition;
      float closestDistance = 10000000000f;
      float tempDistance;
      for(int a = 0; a < RoomSpots.roomSpots.GetLength(0); a++)
      {
        for(int b = 0; b < RoomSpots.roomSpots.GetLength(1); b++)
        {
          tempDistance = Vector2.Distance(tempPosition, new Vector2(a,b));
          if(tempDistance < closestDistance)
          {
            closestDistance = tempDistance;
            closest = new Vector2(a,b);
          }
        }
      }
      if(RoomSpots.roomSpots[(int)closest.x, (int)closest.y] is null)
      {
        RoomSpots.roomSpots[(int)origionalPosition.x, (int)origionalPosition.y] = null;
        RoomSpots.roomSpots[(int)closest.x, (int)closest.y] = draggableObject;
        draggableObject.transform.position = new Vector3(closest.x, closest.y, draggableObject.transform.position.z);
      } else {
        draggableObject.transform.position = new Vector3(origionalPosition.x, origionalPosition.y, draggableObject.transform.position.z);
      }

    }
}
