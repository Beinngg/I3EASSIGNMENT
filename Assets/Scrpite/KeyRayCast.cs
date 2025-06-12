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

        private Renderer lastRenderer = null;
        private Color originalColor;

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = (1 << LayerMask.NameToLayer(ExcludeLayerName)) | layerMaskInteract.value;
            if (Physics.Raycast(transform.position, fwd, out hit, RayLength, mask))
            {
                if (hit.collider.CompareTag(InteractableTag))
                {
                    // Change color of the interactable
                    Renderer rend = hit.collider.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        if (lastRenderer != rend)
                        {
                            // Reset previous renderer color
                            if (lastRenderer != null)
                                lastRenderer.material.color = originalColor;

                            lastRenderer = rend;
                            originalColor = rend.material.color;
                            rend.material.color = Color.yellow; // Highlight color
                        }
                    }

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
                else
                {
                    ResetLastRenderer();
                }
            }
            else
            {
                if (IsCrosshairActive)
                {
                    crosshairChange(false);
                    DoOnce = false;
                }
                ResetLastRenderer();
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

        void ResetLastRenderer()
        {
            if (lastRenderer != null)
            {
                lastRenderer.material.color = originalColor;
                lastRenderer = null;
            }
        }
    }
}
