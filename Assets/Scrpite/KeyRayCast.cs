using UnityEngine;
using System.Collections;

namespace KeySystem
{
    public class KeyRayCast : MonoBehaviour
    {
        [SerializeField] private float RayLength = 5f; // Raycast distance
        [SerializeField] private LayerMask layerMaskInteract; // Layers to include in the raycast
        [SerializeField] string ExcludeLayerName = null; // Layer to exclude from raycast
        private KeyItemController RayCastObject; // Reference to the interactable object hit by raycast
        [SerializeField] KeyCode InteractKey = KeyCode.E; // Key to interact

        string InteractableTag = "Interactable"; // Tag for interactable objects

        private Renderer lastRenderer = null; // Last highlighted object's renderer
        private Color originalColor; // Original color of last highlighted object

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            int mask = (1 << LayerMask.NameToLayer(ExcludeLayerName)) | layerMaskInteract.value; // Combine masks

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
                                lastRenderer.material.color = originalColor; // Reset previous color

                            lastRenderer = rend;
                            originalColor = rend.material.color;
                            rend.material.color = Color.yellow; // Highlight color
                        }
                    }

                    RayCastObject = hit.collider.GetComponent<KeyItemController>(); // Always update reference

                    if (Input.GetKeyDown(InteractKey) && RayCastObject != null)
                    {
                        RayCastObject.ObjectInteraction(); // Interact with the object
                    }
                }
                else
                {
                    ResetLastRenderer(); // Reset highlight if not interactable
                }
            }
            else
            {
                ResetLastRenderer(); // Reset highlight if nothing hit
            }
        }

        void ResetLastRenderer()
        {
            if (lastRenderer != null)
            {
                lastRenderer.material.color = originalColor; // Restore original color
                lastRenderer = null;
            }
        }
    }
}