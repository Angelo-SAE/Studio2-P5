using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    RaycastHit interactableHit;

    [SerializeField] float rayLength;

    [SerializeField] LayerMask interactable;

    void DetectLayerInteractable()
    {
        if (Physics.Raycast(transform.position, transform.forward, out interactableHit, rayLength, interactable))
        {
            Debug.Log("Interactable layert detecetd");

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
