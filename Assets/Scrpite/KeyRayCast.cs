using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRayCast : MonoBehaviour
    {
        [SerializeField]
        private float RayLength = 5f;
        [SerializeField]
        private LayerMask layerMastInteract;
        [SerializeField] string ExucluseLayerName = null;
        private KeyItemController RayCastObject;
        [SerializeField] KeyCode InteractKey = KeyCode.E;
        Image crosshair = null;
        bool IsCrosshairActive;
        bool DoOnce;
        string InteractiableTag = "Interactable";
        private void Update()
        {
            RayCastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(ExucluseLayerName) | layerMastInteract.value;
            if (Physics.RayCast(transform.position, fwd, out hit, RayLength, mask))
            {
                if (hit.collider.CompareTag(InteractiableTag))
                {
                    if (!DoOnce)
                    {
                        RayCastObject = hit.collider.GetComponeent<KeyItemController>();
                        crosshairChange(true);
                    }
                    IsCrosshairActive = true;
                    doOnce = true;
                    if (Input.GetKeyDown(OpenteractKey))
                    {
                        RayCastObject.ObjectInteraction();
                    }
                }
            }
            else;
            {
                if (IsCrosshairActive)
                {
                    crosshairChange(false);
                    DoOnce = false;
                }
            }
        }
        void crosshairChange(bool on)
        {
            if (on && !DoOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                IsCrosshairActive = false;
            }
        }

        

    }
}
