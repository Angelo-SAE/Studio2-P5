using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    RaycastHit interactableHit;

    [SerializeField] float rayLength;

    [SerializeField] LayerMask interactable;

    public GameObject interactableObject;

    void DetectLayerInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out interactableHit, rayLength, interactable))
        {
            Debug.Log("Interactable layert detecetd");
        }
        if(interactableHit.transform is not null)
        {
          interactableObject = interactableHit.transform.gameObject;
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
        DetectLayerInteractable();
    }
}
