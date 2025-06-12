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
        void ObjectInteraction()
        {
            if (RedDoor)
            {
                doorObject.PlayAnimation();
            }
            else if (RedKey)
            {
                _keyInventry.HasRedKey = true;
                ganeObject.SetActive(false);
            }
        }
    }
}