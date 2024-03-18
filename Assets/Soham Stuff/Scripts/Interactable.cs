using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyTypes
{
    blueKey,
    redKey,
    greenKey,
    lightBlueKey
}

public class Interactable : MonoBehaviour
{
    [SerializeField] KeyTypes keyTypes;

    RaycastHit interactableHit;

    [SerializeField] float rayLength;

    [SerializeField] LayerMask interactable;

    public static GameObject interactableObject;


    void DetectLayerInteractable()
    {
        Physics.Raycast(transform.position, transform.forward, out interactableHit, rayLength, interactable);
        if(interactableHit.transform is not null)
        {
          interactableObject = interactableHit.transform.gameObject;
            if (interactableObject.CompareTag("Key"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    OpenDoor.keyList.Add(interactableObject.GetComponent<Key>().keyColor);
                    interactableObject.SetActive(false);
                }
            }
        } else {
          interactableObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        if(Mode.mode3D)
        {
          DetectLayerInteractable();
        } else {
          interactableObject = null;
        }

    }
}
