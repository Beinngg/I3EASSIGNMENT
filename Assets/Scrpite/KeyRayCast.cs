using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace KeySystem
{
    public class KeyRayCast : MonoBehaviour
    {
        [SerializeField]
        private float RayLength = 5f;
        [serializeField]
        private LayerMask layerMastInteract;
        [serializeField] string ExucluseLayerName = null;
         //private KeyItemController RayCastObject;
    }
        
}
