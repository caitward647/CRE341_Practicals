using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeysSystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openCageKey = KeyCode.Mouse0;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "interactiveObject";

        private void Update()
        {
           // Debug.Log("RAYCAST");
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                Debug.Log("Raycast true");
                if (hit.collider.CompareTag(interactableTag))
                {
                    Debug.Log("collided with tag true");
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                      Debug.Log("---" + raycastedObject);
                        crossHairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openCageKey))
                    {
                        raycastedObject.ObjectInteraction();

                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    Debug.Log("crosshair active");
                    crossHairChange(false);
                    doOnce = false;
                }
            }
        }

        void crossHairChange(bool on)
        {
            if (on && !doOnce)
            {
                Debug.Log("RED");
                crosshair.color = Color.red;
            }
            else
            {
                Debug.Log("White");
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}