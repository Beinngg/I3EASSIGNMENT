using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] bool RedDoor = false;
        [SerializeField] bool RedKey = false;
        [SerializeField] KeyInventry _keyInventry = null;
        private KeyDoorController doorObject;

        void Start()
        {
            if (RedDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if (RedDoor)
            {
                if (doorObject != null)
                    doorObject.PlayAnimation();
                else
                    Debug.LogWarning("KeyDoorController not found on this object.");
            }
            else if (RedKey)
            {
                if (_keyInventry != null)
                    _keyInventry.HasRedKey = true;
                else
                    Debug.LogWarning("KeyInventry reference is missing.");
                gameObject.SetActive(false);
            }
        }
    }
}