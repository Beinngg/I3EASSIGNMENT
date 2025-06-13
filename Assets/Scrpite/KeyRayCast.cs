using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
                    Renderer rend = hit.collider.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        if (lastRenderer != rend)
                        {
                            if (lastRenderer != null)
                                lastRenderer.material.color = originalColor;

                            lastRenderer = rend;
                            originalColor = rend.material.color;
                            rend.material.color = Color.yellow;
                        }
                    }

                    if (!DoOnce)
                    {
                        RayCastObject = hit.collider.GetComponent<KeyItemController>();
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
                    DoOnce = false;
                }
                ResetLastRenderer();
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
