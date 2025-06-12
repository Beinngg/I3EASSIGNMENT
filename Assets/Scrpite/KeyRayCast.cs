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
        private LayerMask layerMaskInteract;
        [SerializeField] string ExcludeLayerName = null;
        private KeyItemController RayCastObject;
        [SerializeField] KeyCode InteractKey = KeyCode.E;
        [SerializeField] Image crosshair = null;
        bool IsCrosshairActive;
        bool DoOnce;
        string InteractableTag = "Interactable";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = (1 << LayerMask.NameToLayer(ExcludeLayerName)) | layerMaskInteract.value;
            if (Physics.Raycast(transform.position, fwd, out hit, RayLength, mask))
            {
                if (hit.collider.CompareTag(InteractableTag))
                {
                    if (!DoOnce)
                    {
                        RayCastObject = hit.collider.GetComponent<KeyItemController>();
                        crosshairChange(true);
                    }
                    IsCrosshairActive = true;
                    DoOnce = true;
                    if (Input.GetKeyDown(InteractKey))
                    {
                        RayCastObject.ObjectInteraction();
                    }
                }
            }
            else
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
            if (crosshair == null) return;
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
